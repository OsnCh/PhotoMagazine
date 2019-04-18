using Microsoft.AspNetCore.Identity;
using PhotoMagazine.Business.Services.Interfaces;
using PhotoMagazine.Entitys.Entitys;
using PhotoMagazine.ViewModels.ViewModels;
using PhotoMagazine.Business.Auth.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PhotoMagazine.Entitys.Common.Enums;
using PhotoMagazine.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.ViewModels.ViewModels.Account;
using PhotoMagazine.ViewModels.View.Account;
using PhotoMagazine.Business.Auth;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace PhotoMagazine.Business.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> _userManager;
        private IUserConfirmationCodeRepository _userConfirmationCodeRepository;

        private JwtFactory _jwtFactory;
        private JwtOptions _jwtOptions;

        public AccountService(UserManager<ApplicationUser> userManager,
                              IUserConfirmationCodeRepository userConfirmationCodeRepository,
                              JwtFactory jwtFactory,
                              IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _userConfirmationCodeRepository = userConfirmationCodeRepository;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<(bool, string)> Registration(RegistrationViewModel model)
        {
            if (_userManager.Users.Any(v => v.Email.ToLower() == model.Email.ToLower()))
            {
                return (false, "User with such email already exists.");
            }

            var appUser = new ApplicationUser
            {
                UserName = model.Email.ToLower(),
                Email = model.Email.ToLower(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                JoinDate = DateTime.UtcNow
            };

            var createResult = await _userManager.CreateAsync(appUser, model.Password);
            if (!createResult.Succeeded)
            {
                var errorMsg = GetStringErrors(createResult.Errors);
                return (false, errorMsg);
            }

            await _userManager.AddToRoleAsync(appUser, Role.User.ToString());

            return (true, "Creating user succes");
        }

        public async Task<(string, LoginView)> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null ||
                !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return ("User not found.", null);
            }

            var result = new LoginView
            {
                UserId = user.Id,
                Confirmed = user.EmailConfirmed,
                Token = (user.EmailConfirmed) ? await GetAccessToken(user) : null
            };

            return ("Get login data.", result);
        }

        public async Task<(bool, string)> SendConfirmedCode(string userId)
        {
            var code = GenerateConfirmedCode();
            var updateResult = await _userConfirmationCodeRepository.InsertUpdateUserCode(userId, code);

            if (!updateResult)
            {
                return (false, "Code generation errror.");
            }

            ///Send in smtp

            return (true, "Success code generation.");
        }

        public async Task<(string, SetConfirmedCodeView)> SetConfirmedCode(string userId, string code)
        {
            var codeExist = await _userConfirmationCodeRepository.ConfirmCode(userId, code);

            if (!codeExist)
            {
                return ("Сonfirmation code is incorrect.", null);
            }

            var user = await _userManager.FindByIdAsync(userId);
            var token = await GetAccessToken(user);

            return ("Confirmation code is correct", new SetConfirmedCodeView(token));
        }


        private static string GetStringErrors(IEnumerable<IdentityError> identityErrors)
        {
            var str = string.Join(", ", identityErrors.Select(v => v.Description));
            return str;
        }

        private async Task<string> GetAccessToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            var identity = _jwtFactory.GenerateClaimsIdentity(user, role);

            var (token, expiresIn) = await GenerateJwt(identity, user.UserName);
            return token;
        }

        private async Task<(string token, int expiresIn)> GenerateJwt(ClaimsIdentity identity, string userName)
        {
            var token = await _jwtFactory.GenerateEncodedToken(userName, identity);
            var expiresIn = (int)_jwtOptions.ValidFor.TotalSeconds;
            return (token, expiresIn);
        }

        private string GenerateConfirmedCode()
        {
            var rand = new Random();
            var code = string.Empty;
            for(int i = 0; i < 6; i++)
            {
                code = string.Concat(code, rand.Next(0, 10));
            }
            return code;
        }
    }
}
