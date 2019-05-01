using PhotoMagazine.DataAccess.ResponseModels;
using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories.Interfaces
{
    public interface IPostRepository: IBaseRepository<Post>
    {
        Task<List<GetPostModel>> GetSearchPosts(string query, int position);
    }
}
