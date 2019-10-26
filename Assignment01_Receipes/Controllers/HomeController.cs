using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment01_Receipes.Models;
using System.Data;
using System.Web;


namespace Assignment01_Receipes.Controllers
{
    public class HomeController : Controller
    {
      
        public ViewResult Index()
        {

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
            if (ModelState.IsValid)
            {
                Repository.addRecipe(r);
                return View("RecipeList");
            }
            else
            {
                return View();
            }
        }
        public ViewResult RecipeList()
        {
            return View(Repository.Recipes);
        }
       
        [HttpGet]
        public ViewResult ViewRecipe(int category)
        {
            Recipe re = Repository.Recipes.ElementAt(category);
            return View(re);
        }
        [HttpPost]
        public ViewResult ViewRecipe(Recipe recipe)
        {
            return View(recipe);
        }

        [HttpGet]
        public ViewResult ReviewRecipe(int category)
        {
            Recipe re = Repository.Recipes.ElementAt(category);
            return View(re);
        }
        [HttpPost]
        public ViewResult ReviewRecipe(Recipe recipe)
        {
            return View(recipe);
        }

    }
}
