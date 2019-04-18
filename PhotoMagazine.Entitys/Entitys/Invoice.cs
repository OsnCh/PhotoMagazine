﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("userInvoces")]
    public class Invoice: BaseEntity
    {
        public string UserId { get; set; }
        public uint Count { get; set; }
    }
}
