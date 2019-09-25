using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment01_Receipes.Models
{
    public class Recipe
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter your description: ")]
        public string Description { get; set; }
        public bool giveReview { get; set; }
        public bool inDetail { get; set; }
    }
}
