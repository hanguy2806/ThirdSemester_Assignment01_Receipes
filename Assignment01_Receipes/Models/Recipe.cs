using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment01_Receipes.Models
{
    public class Recipe
    {      
        [Key]
        public int Id { get; set; }     

        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter your description: ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter your ingredient: ")]
        public String Ingredient { get; set; }
        public String imgInfo { get; set; }

     
    }
}
