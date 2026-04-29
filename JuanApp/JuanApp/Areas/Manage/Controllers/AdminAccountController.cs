using JuanApp.Areas.Manage.ViewModels;
using JuanApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JuanApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdminAccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
    {
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                UserName = "_admin",
                FullName = "Admin Adminov",
                Email = "admin@example.com"
            };
            IdentityResult result = await userManager.CreateAsync(admin, "_Admin123!");
            if (!result.Succeeded)
                return Json(result.Errors);
            await userManager.AddToRoleAsync(admin, "Admin");
            return Content("Admin account created successfully.");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }
            AppUser admin = await userManager.FindByNameAsync(loginVm.UserName);
            if (admin == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(loginVm);
            }
            var result = await userManager.CheckPasswordAsync(admin, loginVm.Password);
            if (!result)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(loginVm);
            }
            await signInManager.SignInAsync(admin, true);
            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            var user = await userManager.GetUserAsync(User);
            //return Content($"Username: {user.UserName}, Full Name: {user.FullName}, Email: {user.Email}");
            //return Json(new { user.UserName, user.FullName, user.Email });
            return Json(user);
        }


    }
}
