using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMagazine.Client.Core.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public MvxAsyncCommand LoginAsyncCommand => throw new NotImplementedException();
        public MvxAsyncCommand RegistrationAsyncCommand => throw new NotImplementedException();
    }
}
