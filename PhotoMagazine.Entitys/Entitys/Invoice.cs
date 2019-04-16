using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    public class Invoice: BaseEntity
    {
        public string UserId { get; set; }
        public uint Count { get; set; }
    }
}
