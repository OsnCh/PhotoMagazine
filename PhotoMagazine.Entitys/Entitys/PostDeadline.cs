using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoMagazine.Entitys.Entitys
{
    [Table("PostDeadlines")]
    class PostDeadline: BaseEntity
    {
        public long PostId { get; set; }

        public DateTime Deadline { get; set; }
    }
}
