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
        public int cookingStepId { get; set; }
        public int recipeId { get; set; }
        public String description { get; set; }

    }
}
