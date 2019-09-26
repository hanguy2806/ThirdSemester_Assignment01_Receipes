using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment01_Receipes.Models
{
    public class Recipe
    {

        
        public  int Id;
        public int ID
        {
            get {
                for(int i = 0; i < Repository.Recipes.Count(); i++)
                {
                    Repository.Recipes.ElementAt(i).Id = i + 1;
                }
                return Id;
            }
            set
            {

            }
        
        }

        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter your description: ")]
        public string Description { get; set; }
        public bool giveReview { get; set; }
        public bool inDetail { get; set; }
    }
}
