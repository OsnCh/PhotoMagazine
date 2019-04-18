using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.ViewModels.View.Account
{
    public class LoginView
    {
        public string UserId { get; set; }
        public bool Confirmed { get; set; }
        public string Token { get; set; }
    }
}
