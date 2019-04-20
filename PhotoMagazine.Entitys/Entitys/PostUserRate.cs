using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("PostUserRates")]
    public class PostUserRate: BaseEntity
    {
        public string UserId { get; set; }
        public long PostId { get; set; }
        public uint Value { get; set; }
    }
}
