using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.DataAccess.ResponseModels
{
    public class GetUserHomeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Money { get; set; }
        public int SalePostsCount { get; set; }
        public int PurchasePostsCount { get; set; }
    }
}
