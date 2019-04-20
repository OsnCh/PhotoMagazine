using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("Posts")]
    public class Post: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
