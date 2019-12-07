﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment01_Receipes.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string password = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager=app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user =await userManager.FindByIdAsync("Admin");
            if(user == null)
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, password);
            }
        }
    }
}
