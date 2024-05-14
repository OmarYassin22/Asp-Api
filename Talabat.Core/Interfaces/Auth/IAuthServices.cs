using Microsoft.AspNetCore.Identity;
using Talabat.presentations.Identity;

namespace Talabat.Core.Interfaces.Auth
{
    public interface IAuthServices
    {
        Task<string> GetTokenAsync(ApplicationUser user,UserManager<ApplicationUser> userManager);
    }
}
