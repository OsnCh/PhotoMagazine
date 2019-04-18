using Microsoft.AspNetCore.Identity;
using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Linq;
using System.Text;

namespace PhotoMagazine.Business.Auth.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("id");
            if (claim == null)
            {
                return String.Empty;
            }
            return claim.Value;
        }
    }
}
