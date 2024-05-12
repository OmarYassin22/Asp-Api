using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Interfaces.Auth;
using Talabat.presentations.Identity;

namespace Talabat.Service
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;

        public AuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            // private claims
            var AuthClaims = new List<Claim>()
          {
              new Claim(ClaimTypes.Name,user.DisplayName),
              new Claim(ClaimTypes.Email,user.Email),
          };
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:SecurityKey"]));

            //parts of token
            var tokenParts = new JwtSecurityToken(
                //payload
                audience: user.DisplayName,
                issuer: _configuration["jwt:Issuer"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["jwt:Duration"])),
                claims: AuthClaims,
                // Header + singture
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                );
            // create final token 

            return new JwtSecurityTokenHandler().WriteToken(tokenParts);

        }
    }
}
