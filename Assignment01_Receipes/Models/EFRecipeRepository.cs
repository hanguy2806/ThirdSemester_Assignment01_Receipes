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
        public IQueryable<CookingStep> CookingSteps => context.CookingSteps;


        public void addRecipe(Recipe re)
        {
            context.Recipes.Add(re);
        }
        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(r => r.Id == recipeId);
            if(recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }
        public void SaveRecipe(Recipe re)
        {
            Recipe recipeEntry = getRecipeByID(re.Id);
            if (recipeEntry != null)
            {
                recipeEntry.Name = re.Name;
                recipeEntry.Description = re.Description;
                recipeEntry.Ingredient = re.Ingredient;
                recipeEntry.CookingSteps = re.CookingSteps;
            }

            context.SaveChanges();
        }

        public void addCookingStep(CookingStep cs)
        {
            
            Recipe r = context.Recipes.FirstOrDefault(re => re.Id == cs.recipeId);
            if (r.CookingSteps == null)
            {
                r.CookingSteps = new List<CookingStep>();
            }
            r.CookingSteps.Add(cs);

            context.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }


        public Recipe getRecipeByID(int recipeId)
        {
            Recipe recipe = this.Recipes.FirstOrDefault(r => r.Id == recipeId);
            //Load the cooking steps to recipe
            IQueryable<CookingStep> steps = CookingSteps.Where(ck => ck.recipeId == recipeId);
            recipe.CookingSteps = steps.ToList();
            return recipe;
        }
    }
}
