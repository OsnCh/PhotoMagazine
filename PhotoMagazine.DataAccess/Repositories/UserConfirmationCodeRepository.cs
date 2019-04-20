using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.Entitys.Entitys;
using System;
using Dapper;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories
{
    public class UserConfirmationCodeRepository : BaseRepository<UserConfirmationCode>, IUserConfirmationCodeRepository
    {
        public UserConfirmationCodeRepository(DataConfiguration dataConfiguration) : base(dataConfiguration)
        {
        }

        public async Task<bool> InsertUpdateUserCode(string userId, string confirmationCode)
        {
            var sql = @"UPDATE UserConfirmationCodes SET ConfirmationCode = @confirmationCode
                        WHERE UserId = @userId;

                        INSERT UserConfirmationCodes(UserId, ConfirmationCode)
                        SELECT @userId, @confirmationCode 
                        WHERE NOT EXISTS(SELECT * FROM UserConfirmationCodes WHERE UserId = @userId); ";

            using (var transaction = Connection.BeginTransaction())
            {
                try
                {
                    await Connection.ExecuteAsync(sql, 
                        new { userId = userId, confirmationCode = confirmationCode }, 
                        transaction);
                    transaction.Commit();
                    return true;
                }catch(Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        
        public async Task<bool> ConfirmCode(string userId, string confirmationCode)
        {
            var sql = @"DECLARE @codeExist bit;
                        Set @codeExist = CASE WHEN EXISTS(SELECT * FROM UserConfirmationCodes 
                        WHERE UserID = @userId AND ConfirmationCode = @code) THEN 1 ELSE 0  
                        END
                        UPDATE AspNetUsers SET EmailConfirmed = @codeExist;
                        SELECT @codeExist;";

            using (var transaction = Connection.BeginTransaction())
            {
                try
                {
                    var codeExist = await Connection.QuerySingleAsync<bool>(sql, 
                        new { userId = userId, code = confirmationCode }, transaction);
                    transaction.Commit();
                    return codeExist;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
