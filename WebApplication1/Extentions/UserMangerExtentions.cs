using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.presentations.Identity;

namespace Talabat.presentations.Extentions
{
    public static class UserMangerExtentions
    {
        public static async Task<ApplicationUser?> FindUserWithAddressAsync(this UserManager<ApplicationUser> userManger ,ClaimsPrincipal user)
        {
           var email= user.FindFirstValue(ClaimTypes.Email);
            var response= await userManger.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

            return response;

        }
    }
}
