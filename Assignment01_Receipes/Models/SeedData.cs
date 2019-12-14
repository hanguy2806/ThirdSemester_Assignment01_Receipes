using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                     new Recipe
                     {
                         Name = "Spaghetti",
                         Description = "This creates a great, chunky, and very meaty spaghetti sauce",
                         Ingredient = " It combines sweet Italian sausage and ground beef in a seasoned tomato sauce.",
                         imgInfo = "~/Content/images/spaghetti.jpg",
                         
                     },
        new Recipe
        {
            Name = "Pasta",
            Description = "Not to be confused with authentic Hungarian Goulash, but an easy American-style skillet meal full of comfort all the same.",
            Ingredient = "Used the fresh spinach as a bed for the pasta & was great",
            imgInfo = "~/Content/images/pasta.jpg"
            
        },
        new Recipe
        {
            Name = "Pizza",
            Description = "Pizza and the flavors of Creole cuisine blend amazingly well in this hearty dish with a crispy crust. Add more hot sauce to boost the heat if you like things spicy.",
            Ingredient = "Onion, Mushroom,Shrimp,mozzarella cheese",
            imgInfo = "~/Content/images/pizza.jpg"
        },
        new Recipe
        {
            Name = "Ham",
            Description = "Spiral-sliced hams are fully cooked city hams and can be served cold out of the package, but most people prefer to glaze and heat before they eat.",
            Ingredient = "Ham is a cut of meat taken from the back legs or sometimes the shoulders of a pig",
            imgInfo = "~/Content/images/ham.jpg"
        }
                    );
                context.SaveChanges();
            }
        }
    }
}
