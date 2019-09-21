using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment01_Receipes.Models;


    public static class Repository
    {
        private static List<Recipe> recipes = new List<Recipe>
        {
            new Recipe {name="Spaghetti", description="there are 3 steps" },
            new Recipe {name="Pasta", description="there are 4 steps" },
            new Recipe {name="Pizza", description="there are 5 steps" },
            new Recipe {name="Ham", description="there are 6 steps" },
        };
        public static IEnumerable<Recipe> Recipes
        {
            get
            {
                return recipes;
            }
        }
        public static void addRecipe(Recipe r)
        {
            recipes.Add(r);
        }
    }

