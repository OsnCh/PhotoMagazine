using PhotoMagazine.Business.Services.Interfaces;
using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.ViewModels.View.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.Business.Services
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(string, UserHomeView)> GetUserHomeView(string userId)
        {
            var dbResponse = await _userRepository.GetUserHomeData(userId);

            var response = new UserHomeView
            {
                FirstName = dbResponse.FirstName,
                LastName = dbResponse.LastName,
                Money = dbResponse.Money,
                PurchasePostsCount = dbResponse.PurchasePostsCount,
                SalePostsCount = dbResponse.SalePostsCount
            };

            var msg = "Get user home data.";

            return (msg, response);
        }
    }
}
