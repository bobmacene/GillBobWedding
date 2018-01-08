using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GillBobWedding.Models;

namespace GillBobWedding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Location()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

    }
}
