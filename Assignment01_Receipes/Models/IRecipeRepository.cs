using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        void addRecipe(Recipe r);
        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int recipeId);
        void addCookingStep(CookingStep cs);
        Recipe getRecipeByID(int recipeId);
    }
}
