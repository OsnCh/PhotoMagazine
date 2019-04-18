using PhotoMagazine.ViewModels.View.Account;
using PhotoMagazine.ViewModels.ViewModels;
using PhotoMagazine.ViewModels.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<(bool, string)> Registration(RegistrationViewModel model);
        Task<(string, LoginView)> Login(LoginViewModel model);
        Task<(bool, string)> SendConfirmedCode(string userId);
        Task<(string, SetConfirmedCodeView)> SetConfirmedCode(string userId, string code);
    }
}
