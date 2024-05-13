using Microsoft.AspNetCore.Identity;

namespace Talabat.presentations.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string? DisplayName { get; set; } = null!;
        public Address Address { get; set; } = null;
        
    }
}
