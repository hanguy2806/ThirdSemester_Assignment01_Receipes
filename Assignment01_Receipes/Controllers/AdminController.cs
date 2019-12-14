﻿using Assignment01_Receipes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        private IRecipeRepository repository;
        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }       
             
        public ViewResult Index() => View();
        
        public ViewResult RecipePage() => View(repository.Recipes);    

        [HttpGet]
        public ViewResult AddCookingStep(int id)
        {
            CookingStep cs = new CookingStep();
            cs.recipeId = id;
            return View(cs);
        }

        [HttpPost]
        public ViewResult AddCookingStep(CookingStep cs)
        {
            repository.Recipes.FirstOrDefault(r => r.Id == cs.recipeId);
              //  .addCookingStep(cs);
            return View("RecipePage", repository.Recipes);
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
                repository.addRecipe(r);
                repository.SaveRecipe(r);
                return View("RecipePage", repository.Recipes);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult Edit(int recipeId) => View(repository
           .Recipes.FirstOrDefault(r => r.Id == recipeId));
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
