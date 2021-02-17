using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly MovieShopDbContext _dbContext;
        public GenresController(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            // get all the list of genres from database
            var genres = _dbContext.Genres.ToList();
            // select * from genres

            return View();
        }
    }
}
