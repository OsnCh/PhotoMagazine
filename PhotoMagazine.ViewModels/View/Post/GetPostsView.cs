using PhotoMagazine.ViewModels.View.Post.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.ViewModels.View.Post
{
    public class GetPostsView
    {
        public List<GetPostsItemModel> Posts { get; set; }

        public GetPostsView()
        {
            Posts = new List<GetPostsItemModel>();
        }
    }
}
