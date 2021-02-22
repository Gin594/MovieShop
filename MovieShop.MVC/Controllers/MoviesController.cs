using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Infrastructure.Services;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
   
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _movieService.GetMovieById(id);
            return View(movieDetail);
        }

        [HttpGet]
        public IActionResult TopRevenueMovies()
        {
            //var movies = _movieService.GetHighestGrossingMovies();
            return View("TopRevenueMovies");
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            return View("TopRatedMovies");
        }

        [HttpGet]
        public IActionResult Genre(int genreId)
        {
            // var movie = get data by  genre id = 2; 
            // return View("Genre", movie);
            return View("Genre");
        }

        [HttpGet]
        public IActionResult Reviews(int movieId)
        {
            // var review = get data by movie id = 1;
            // return View("Reviews", review);
            return View("Reviews");
        }

        
    }
}
