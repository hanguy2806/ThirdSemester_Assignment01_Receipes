﻿using Assignment01_Receipes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01_Receipes.Controllers
{
    [Authorize]
    public class AccountController:Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser>userMgr,SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        [AllowAnonymous]
       public ViewResult Login(String returnUrl)
        {
            return View(new LoginModel {
            ReturnUrl=returnUrl});
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if(user != null)
                {
                    if((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded){
                        return Redirect(loginModel.ReturnUrl ?? "Admin/Index");
                    }
                   
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
    }
}
