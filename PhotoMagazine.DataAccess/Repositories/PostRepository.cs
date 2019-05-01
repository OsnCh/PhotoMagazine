using Dapper;
using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.DataAccess.ResponseModels;
using PhotoMagazine.Entitys.Common;
using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DataConfiguration dataConfiguration) : base(dataConfiguration)
        {
        }

        public async Task<List<GetPostModel>> GetSearchPosts(string query, int position)
        {
            var sql = @"SELECT P.Name AS Title,
                        	   P.Description AS Description,
                        	   P.Status AS Status,
                        	   Ph.Data AS Photo,
                        	   PD.Deadline AS Deadline  
                        FROM posts AS P
                        LEFT JOIN PostPhotos AS PPh ON P.Id = PPh.PostId
                        LEFT JOIN Photos AS Ph ON PPh.PhotoId = Ph.Id
                        LEFT JOIN PostDeadlines AS PD ON PD.PostId = P.Id
                        WHERE (P.Name LIKE @query OR P.Description LIKE @query) AND 
                        P.Status = 0
                        ORDER BY P.Id
                        OFFSET @position ROWS FETCH NEXT @countLazyLoading ROWS ONLY;";

            var result = await Connection.QueryAsync<GetPostModel>(sql, 
                new { query = query, position = position, countLazyLoading = Constants.CountRecordLazyLoading });
            return result.ToList();
        }
    }
}
