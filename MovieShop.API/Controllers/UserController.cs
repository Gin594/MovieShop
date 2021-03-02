using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ICurrentLogedInUser _currentLogedInUser;

        public UserController(IUserService userService, ICurrentLogedInUser currentLogedInUser)
        {
            _userService = userService;
            _currentLogedInUser = currentLogedInUser;
        }

        [Authorize]
        [HttpGet("{id:int}/purchases")]
        public async Task<ActionResult> GetUserPurchasedMoviesAsync(int id)
        {
            if (id != _currentLogedInUser.UserId.Value)
            {
                return Unauthorized("Hey you cannot access other person info");
            }
            //var userMovies = await _userService.GetAllPurchasesForUser(id);
            //return Ok(userMovies);
            return Ok();
        }
    }
}
