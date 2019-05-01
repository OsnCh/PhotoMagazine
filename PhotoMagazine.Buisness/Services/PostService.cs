using PhotoMagazine.Business.Services.Interfaces;
using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.Entitys.Common;
using PhotoMagazine.Entitys.Common.Enums;
using PhotoMagazine.ViewModels.View.Post;
using PhotoMagazine.ViewModels.View.Post.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.Business.Services
{
    public class PostService: IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<(string, GetPostsView)> GetPosts(string search, int position)
        {
            var dbResponse = await _postRepository.GetSearchPosts(search, position);

            var response = dbResponse.Select(v => new GetPostsItemModel
            {
                Title = v.Title,
                Description = v.Description,
                Photo = v.Photo,
                Deadline = v.Deadline - DateTime.UtcNow,
                IsSoldOut = v.Status == PostStatus.SoldOut
            }).ToList();

            return ($"Get posts with {position} by {position + Constants.CountRecordLazyLoading}",
                new GetPostsView { Posts = response });
        }
    }
}
