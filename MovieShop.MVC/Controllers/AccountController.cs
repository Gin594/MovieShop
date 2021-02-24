using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest, string returnUrl = null)
        {
            // if returnUrl === null then we go to home page
            // otherwise go to the returnUrl
            returnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return View();
            }

            // send this loginRequest model to the UserService that will validate
            // the user name and password
            var user = await _userService.ValidateUser(loginRequest);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Please check username and password");
                return View();
            }

            // if un/pw is success

            // Cookie base authentication

            // Create a cookie with some information such that id, firstname, lastname, roles etc. ClAIMS
            // that information should not be in plain text, it should be encrypted

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToShortDateString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(returnUrl);

        }

        [HttpGet]
       public async Task<IActionResult> Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout ()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel requestModel)
        {
            // Model Binding
            // Form, it will look for input elements names and if those names match with our Action method
            // model properties, then it will automatically map that data

            // a control with name=email "abc@abc.com" (case insensitive)
            // UserRegisterRequestModel => Email
            // not only for object, also binding if match the parameters

            if (!ModelState.IsValid)
            {
                return View();
            }
            // only when every validation passes make sure you save to database
            var createdUser = await _userService.RegisterUser(requestModel);
            if (createdUser)
            {
                return RedirectToAction("Login");

            }
            return View(); 
        }
    }
}
