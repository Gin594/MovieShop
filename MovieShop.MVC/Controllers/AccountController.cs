using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // var account = get data by account id = 2;
            // return View("Details", account);
            return View("Details");
        }

        [HttpPost]
        public IActionResult Create(object account)
        {
            // var result = insert data into database
            // return View("Create", result);
            return View("Create");
        }

        [HttpPost]
        public IActionResult Login(object user)
        {
            // get user email, name, password and verify them from database
            // if match then generate authentication
            return View("Login");
        }
    }
}
