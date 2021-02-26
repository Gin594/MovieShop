using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Core.Models.Request;
namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        public UserController(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        [HttpGet]
        //[Authorization]
        public async Task<IActionResult> BuyMovie(int id)
        {
            // call userService to save the movie that will call
            // repository to save in purchase table
            var movie = await _movieService.GetMovieById(id);
            PurchaseRequestModel purchaseRequestModel = new PurchaseRequestModel
            {
                MovieId = movie.Id,
                Price = movie.Price,
                Title = movie.Title,
                PostUrl = movie.PosterUrl
            };
            return View(purchaseRequestModel);
        }

        [HttpPost]
        //[Authorization]
        public async Task<IActionResult> BuyMovie(PurchaseRequestModel purchaseRequestModel, string returnUrl=null)
        {
            returnUrl ??= Url.Content("~/");
            // call userService to save the movie that will call
            // repository to save in purchase table
            await _userService.PurchaseMovie(purchaseRequestModel);
            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Review(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            ReviewRequestModel reviewRequestModel = new ReviewRequestModel
            {
                MovieId = movie.Id,
                PostUrl = movie.PosterUrl,
                Title = movie.Title
            };
           
            return View(reviewRequestModel);
        }

        [HttpPost]
        public async Task<IActionResult> Review(ReviewRequestModel reviewRequestModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _userService.AddMovieReview(reviewRequestModel);
            return LocalRedirect(returnUrl);

        }
    }
}
