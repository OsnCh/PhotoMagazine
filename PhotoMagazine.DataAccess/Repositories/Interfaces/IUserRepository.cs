using PhotoMagazine.DataAccess.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository: IDisposable
    {
        Task<GetUserHomeModel> GetUserHomeData(string userId);
    }
}
