using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment01_Receipes.Models;


public static class Repository
{
    private static List<Recipe> recipes = new List<Recipe>{};
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

