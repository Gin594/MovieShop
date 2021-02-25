using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin. SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(object movie)
        {
            // var movie = insert movie detail into database
            // return View("Create", movie);
            return View("Create");
        }

        [HttpPut("/movie/edit")]
        public IActionResult Edit(object movie)
        {
            // var movie = insert movie detail into database
            // return View("Edit", movie);
            return View("Edit");
        }
    }
}
