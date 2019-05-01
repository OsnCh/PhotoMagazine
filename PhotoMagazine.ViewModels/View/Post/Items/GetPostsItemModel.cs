using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.ViewModels.View.Post.Items
{
    public class GetPostsItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public TimeSpan Deadline { get; set; }
        public bool IsSoldOut { get; set; }
    }
}
