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
        private IRecipeRepository repository;
        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {

            return View();
        }
        
        public ViewResult RecipeList()
        {
            return View(repository.Recipes);
        }
       
        [HttpGet]
        public ViewResult ViewRecipe(int recipeId)
        {
            Recipe re = repository.Recipes.FirstOrDefault(r=>r.Id==recipeId);
            Recipe rep = repository.getRecipeByID(re.Id);
            return View(rep);
        }
        [HttpPost]
        public ViewResult ViewRecipe(Recipe recipe)
        {
            return View(recipe);
        }

        [HttpGet]
        public ViewResult ReviewRecipe(int recipeId)
        {
            Recipe re = repository.Recipes.FirstOrDefault(r => r.Id == recipeId);
            return View(re);
        }
        [HttpPost]
        public ViewResult ReviewRecipe(Recipe recipe)
        {
            return View(recipe);
        }

    }
}
