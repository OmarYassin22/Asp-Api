using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.presentations.Identity;

namespace Talabat.Core.Interfaces.Auth
{
    public interface IAuthServices
    {
        Task<string> GetTokenAsync(ApplicationUser user,UserManager<ApplicationUser> userManager);
    }
}
