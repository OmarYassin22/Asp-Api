using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.presentations.Identity;

namespace Talabat.Repo.Identity
{
    public static class ApplicationSeeding
    {
        public static async Task UserSeed(UserManager<ApplicationUser> userManager)
        {


            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    DisplayName = "Omar",
                    Email = "omar@gmail.com",
                    UserName = "omar",
                    PhoneNumber = "11223344"

                };
                await userManager.CreateAsync(user);

            }

        }
    }
}
