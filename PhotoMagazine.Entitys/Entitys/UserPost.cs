using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("UserPosts")]
    class UserPost: BaseEntity
    {
        public string UserId { get; set; }
        public long PostId { get; set; }
    }
}
