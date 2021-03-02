using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Exceptions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel loginRequestModel)
        {

            if (!ModelState.IsValid)
            {
                throw new ConfilictException("Request not valid");
            }

            // send this loginRequest model to the UserService that will validate
            // the user name and password
            var user = await _userService.ValidateUser(loginRequestModel);
            if (user == null)
            {
                //ModelState.AddModelError(string.Empty, "Please check username and password");
                //throw new ConfilictException("Please check username and password");
                return Unauthorized();
            }
            var tokenObject = new { token = _jwtService.GenerateJWT(user) };
            // if un/pw is success

            // Cookie base authentication

            // Create a cookie with some information such that id, firstname, lastname, roles etc. ClAIMS
            // that information should not be in plain text, it should be encrypted

            //var claims = new List<Claim> {
            //    new Claim(ClaimTypes.Name, user.Email),
            //    new Claim(ClaimTypes.GivenName, user.FirstName),
            //    new Claim(ClaimTypes.Surname, user.LastName),
            //    new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToShortDateString()),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //};
            //if (user.Roles != null) claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity));

            return Ok(tokenObject);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(UserRegisterRequestModel registerRequestModel)
        {
            if (!ModelState.IsValid)
            {
                throw new ConfilictException("Request not valid");
            }
            // only when every validation passes make sure you save to database
            var createdUser = await _userService.RegisterUser(registerRequestModel);
            if (createdUser)
            {
                throw new ConfilictException("User already created");

            }
            return Ok(createdUser);
        }
    }


}
