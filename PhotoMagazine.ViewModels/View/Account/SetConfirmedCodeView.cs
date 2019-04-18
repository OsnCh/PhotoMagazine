using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.ViewModels.View.Account
{
    public class SetConfirmedCodeView
    {
        public SetConfirmedCodeView()
        {

        }

        public SetConfirmedCodeView(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
