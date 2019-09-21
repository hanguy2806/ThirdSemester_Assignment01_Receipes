using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01_Receipes.Controllers
{
    public class HomeController :Controller
    {
        public ViewResult Home()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good night" ;
            return View();
        }
        public ViewResult AddRecipe()
        {
            return View();
        }
    }
}
