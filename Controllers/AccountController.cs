using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySchoolProject.Data;
using MySchoolProject.Models;
using MySchoolProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly DbOperations operations;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,RoleManager<ApplicationRole> roleManager,DbOperations operations)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.operations = operations;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            await signInManager.SignOutAsync();
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl = null)
        {
            if(ModelState.IsValid)
            {      
                var result  = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    var user = await operations.FindByNameAsync(model.Email);
                    await signInManager.SignInAsync(user, model.RememberMe);
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("home","dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
             
            }

            return View(model);

        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                /////check if the user is in admission list
                //var isAdmitted = await operations.IsUserAdmittedAsync(model.Email);
                //if (!isAdmitted.Succeeded)
                //{
                //    ModelState.AddModelError("", "Sorry, you were are not given admission");
                //    return View(model);
                //}

                var user = new ApplicationUser { UserName = model.Email, PasswordHash = model.Password, Email = model.Email };
              var result =   await userManager.CreateAsync(user, model.Password);



                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Home", "Dashboard");
                    }

                }
            }
            return View(model);
        }
    }
}
