using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhotoMagazine.Entitys.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using PhotoMagazine.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using PhotoMagazine.Entitys.Common.Enums;

namespace PhotoMagazine.Business.Auth
{
    public class Identity
    {
        public static async Task Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            string[] roles = new string[] { "SuperAdmin", "Admin", "User" };
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    var nr = new IdentityRole(role)
                    {
                        NormalizedName = role.ToUpper()
                    };
                    await roleStore.CreateAsync(nr);
                }
            }

            string email = configuration["AdminDetail:Email"];
            string adminPassword = configuration["AdminDetail:Password"];
            string firstName = configuration["AdminDetail:FirstName"];
            string lastName = configuration["AdminDetail:LastName"];

            var admin = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                JoinDate = DateTime.UtcNow
            };

            if (!context.Users.Any(u => u.Email == admin.Email))
            {
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await AssignRole(userManager, admin.Email, Role.SuperAdmin.ToString());
                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task<IdentityResult> AssignRole(UserManager<ApplicationUser> userManager, string email, string role)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            var result = await userManager.AddToRoleAsync(user, role);
            return result;
        }
    }
}
