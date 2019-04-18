using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories.Interfaces
{
    public interface IUserConfirmationCodeRepository: IBaseRepository<UserConfirmationCode>
    {
        Task<bool> InsertUpdateUserCode(string userId, string confirmationCode);
        Task<bool> ConfirmCode(string userId, string confirmationCode);
    }
}
