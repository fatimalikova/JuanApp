using JuanApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JuanApp.Controllers
{
    public class AccountController
        (
        UserManager <AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<IdentityRole> roleManager
        ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateRole()
        //{
        //  await roleManager.CreateAsync(new IdentityRole("Admin"));
        //  await roleManager.CreateAsync(new IdentityRole("User"));
        //  await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //  return Content("Role created");
        //}


        public IActionResult Register()
        {
            return View();
        }
    }
}
