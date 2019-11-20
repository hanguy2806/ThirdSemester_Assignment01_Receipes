using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
    }
}
