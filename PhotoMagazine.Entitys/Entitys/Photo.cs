using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("Photos")]
    public class Photo: BaseEntity
    {
        public byte[] Data { get; set; }
    }
}
