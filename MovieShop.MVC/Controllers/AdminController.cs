using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(object movie)
        {
            // var movie = insert movie detail into database
            // return View("Create", movie);
            return View("Create");
        }

        [HttpPut]
        public IActionResult Edit(object movie)
        {
            // var movie = insert movie detail into database
            // return View("Edit", movie);
            return View("Edit");
        }
    }
}
