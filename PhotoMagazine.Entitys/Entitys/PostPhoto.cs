using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("PostPhotos")]
    class PostPhoto:BaseEntity
    {
        public long PostId { get; set; }
        public long PhotoId { get; set; }
    }
}
