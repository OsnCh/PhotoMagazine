using PhotoMagazine.ViewModels.View.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.Business.Services.Interfaces
{
    public interface IPostService
    {
        Task<(string, GetPostsView)> GetPosts(string search, int position);
    }
}
