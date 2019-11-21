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
        public ViewResult RecipePage() => View(repository.Recipes);
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        public ViewResult Edit(int id) => View(repository
            .Recipes.FirstOrDefault(p => p.Id == id));

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
                return RedirectToAction("RecipePage");
            }
            else
            {
                return View(r);
            }
        }
    }
}
