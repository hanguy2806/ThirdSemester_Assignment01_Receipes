using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public interface ICookingStepRepository
    {
        IQueryable<CookingStep> CookingSteps { get; }
        void addRecipe(Recipe r);
        /*void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int recipeId);
        */
    }
}
