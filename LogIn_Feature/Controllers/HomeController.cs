using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogIn_Feature.Models;

namespace LogIn_Feature.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Submit(string username, string pass)
        {
            //check the infos
            Models.HomeModel h = new HomeModel();
            h.username = username;
            h.password = pass;
            bool re = h.Validate();
            if (re is true)
            {
                return Content($"hello {username}");
            }

            return View();
        }
    }
}
