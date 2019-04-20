using Dapper;
using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.DataAccess.ResponseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DataConfiguration dataConfiguration) : base(dataConfiguration)
        {
        }

        public async Task<GetUserHomeModel> GetUserHomeData(string userId)
        {
            var sql = @"SELECT U.FirstName, U.LastName,
                        	ISNULL(I.Count, 0) AS [Money],
                            (SELECT COUNT(P.Id) FROM UserPosts AS UP
                        		LEFT JOIN posts AS P ON P.Id = UP.PostId
                        		WHERE UP.UserId = @userId
                        		AND [P].[Status] = 0) AS [SalePostsCount],
                        	(SELECT COUNT(P.Id) FROM UserPosts AS UP
                        		LEFT JOIN posts AS P ON P.Id = UP.PostId
                        		WHERE UP.UserId = @userId
                        		AND [P].[Status] = 1) AS [PurchasePostsCount]
                        FROM AspNetUsers AS U
                        LEFT JOIN UserInvoces AS I ON I.UserId = U.Id
                        WHERE U.Id = @userId;";

            var response = await Connection.
                QuerySingleAsync<GetUserHomeModel>(sql, new { userId = userId });
            return response;
        }
    }
}
