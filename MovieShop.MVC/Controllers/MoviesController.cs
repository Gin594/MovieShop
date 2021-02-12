using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View("Testing");
        }

        [HttpGet]
        public IActionResult TopRevenueMovies()
        {
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
