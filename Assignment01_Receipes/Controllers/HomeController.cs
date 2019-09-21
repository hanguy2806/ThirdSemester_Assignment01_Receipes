using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment01_Receipes.Models;

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
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddRecipe(Recipe r)
        {
            Repository.addRecipe(r);
            return View("ViewRecipe");
        }
        
    }
}
