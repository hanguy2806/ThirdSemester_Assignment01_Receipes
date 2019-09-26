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
            return View("RecipeList");
        }
       
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddRecipe(Recipe r)
        {
            if(ModelState.IsValid){
                Repository.addRecipe(r);
                return View("RecipeList",Repository.Recipes);
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
        public ViewResult ReviewRecipe()
        {
            return View();
        }
        public ViewResult ViewRecipe()
        {
            return View();
        }
              
        [HttpGet]
        public ActionResult ReviewRecipe(int id)
        {
            Recipe re = Repository.Recipes.ElementAt(id-1);
                return View(re);
        }
        [HttpPost]
        public ActionResult ReviewRecipe(Recipe recipe)
        {            
            return View(recipe);
        }
        [HttpGet]
        public ActionResult ViewRecipe(int id)
        {
            Recipe re = Repository.Recipes.ElementAt(id-1);
            return View(re);
        }
        [HttpPost]
        public ActionResult ViewRecipe(Recipe recipe)
        {
            return View(recipe);
        }
    } 
}
