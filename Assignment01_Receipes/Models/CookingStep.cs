using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public class CookingStep
    {
        [Key]
        public int cookingStepId;
        public int recipeId;
        public String description;
       
    }
}
