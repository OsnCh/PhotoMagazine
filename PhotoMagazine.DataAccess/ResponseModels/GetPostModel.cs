using PhotoMagazine.Entitys.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.DataAccess.ResponseModels
{
    public class GetPostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PostStatus Status { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Deadline { get; set; }
    }
}
