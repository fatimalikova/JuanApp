using System;
using System.Linq;
using JuanApp.Data;
using JuanApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly JuanDbContext _context;

        public ProductsController(JuanDbContext context)
        {
            _context = context;
        }

        public IActionResult Detail(Guid id)
        {
            var product = _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            var related = _context.Products
                .Include(p => p.ProductImages)
                .Where(p => p.Id != product.Id && p.IsNew == product.IsNew)
                .Take(4)
                .ToList();

            ProductVm productVm = new()
            {
                Product = product,
                RelatedProducts = related
            };

            return View(productVm);
        }

        //public IActionResult ProductModal(Guid id)
        //{
        //    var product = _context.Products
        //        .Include(p => p.ProductImages)
        //        .FirstOrDefault(p => p.Id == id);

        //    if (product == null)
        //        return NotFound();

        //    return PartialView("_ProductModalPartialView", product);
        //}
    }
}
