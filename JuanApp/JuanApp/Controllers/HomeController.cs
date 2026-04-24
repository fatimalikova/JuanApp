using JuanApp.Data;
using JuanApp.Models;
using JuanApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JuanApp.Controllers
{
    public class HomeController(JuanDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm
            {
                Sliders = _context.Sliders.ToList(),
                NewProducts = _context.Products
                .Include(p => p.ProductImages)
                .Where(p => p.IsNew).ToList(),

                Blogs = _context.Blogs.ToList()
            };
            return View(homeVm);
        }

     
    }
}
