using PhotoMagazine.ViewModels.View.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<(string, UserHomeView)> GetUserHomeView(string userId);
    }
}
