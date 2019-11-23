using Assignment01_Receipes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Controllers
{
    public class AdminController:Controller
    {
        private IRecipeRepository repository;
        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Recipes);
        public ViewResult RecipePage() => View(repository.Recipes);
      
        
        public ViewResult Edit(int recipeId) => View(repository
            .Recipes.FirstOrDefault(r => r.Id == recipeId));
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
                repository.addRecipe(r);
                repository.SaveRecipe(r);
                return View("RecipePage", repository.Recipes);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Edit(Recipe r)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(r);
                TempData["message"] = $"{r.Name} has been saved!";
                return RedirectToAction("RecipePage",repository.Recipes);
            }
            else
            {
                return View(r);
            }
        }
        
        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
            if(deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted!";

            }
            return RedirectToAction("RecipePage");
        }
    }
}
