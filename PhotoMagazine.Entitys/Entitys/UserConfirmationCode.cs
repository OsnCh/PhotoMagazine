using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("UserConfirmationCodes")]
    public class UserConfirmationCode: BaseEntity
    {
        public string UserId { get; set; }
        public string ConfirmationCode { get; set; }
    }
}
