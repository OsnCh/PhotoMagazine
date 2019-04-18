using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoMagazine.ViewModels.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email unavailable.")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password contains more than 6 characters")]
        public string Password { get; set; }
    }
}
