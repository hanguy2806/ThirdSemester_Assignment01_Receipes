using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public class EFRecipeRepository :IRecipeRepository
    {
        private ApplicationDbContext context;
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Recipe> Recipes => context.Recipes;

        public void addRecipe(Recipe re)
        {
            context.Recipes.Add(re);
        }
        public void SaveRecipe(Recipe re)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(r => r.Id == re.Id);
            if(recipeEntry != null)
            {
                recipeEntry.Name = re.Name;
                recipeEntry.Description = re.Description;
                recipeEntry.Ingredient = re.Ingredient;
            }
            context.SaveChanges();
        }
       

    }
}
