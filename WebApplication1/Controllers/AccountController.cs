using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using Talabat.Core.Interfaces.Auth;
using Talabat.presentaion.Controllers;
using Talabat.presentations.DTOs;
using Talabat.presentations.Errors;
using Talabat.presentations.Identity;

namespace Talabat.presentations.Controllers
{

    public class AccountController : BaseAPIController

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthServices _authServices;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthServices authServices,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authServices = authServices;
            _mapper = mapper;
        }
        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return Unauthorized(new ApiResponease(401));

            var response = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!response.Succeeded) return Unauthorized(new ApiResponease(401, "Wrong Password"));
            // make json camelCase
            var option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            return Ok(JsonSerializer.Serialize(new UserDto()
            {
                DisplayName = user?.DisplayName,
                Email = user.Email,
                Token = await _authServices.GetTokenAsync(user, _userManager)
            },
                options: option));
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> register(RegisterDto model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                DisplayName = model.DisplayName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email.Split('@')[0]
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(new ApiValidations() { Details = result.Errors.Select(e => e.Description).ToList() });
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authServices.GetTokenAsync(user, _userManager)
            }); ;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCuerrentUsre()
        {


            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var response = _mapper.Map<ApplicationUser,UserDto>(user);
            response.Token= await _authServices.GetTokenAsync(user,_userManager);
            return response;


        }
    }
}
