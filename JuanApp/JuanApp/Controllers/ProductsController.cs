//using JuanApp.Data;
//using JuanApp.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace JuanApp.Controllers
//{
//    public class ProductsController(JuanDbContext _context) : Controller
//    {
//        public IActionResult Detail(Guid id)
//        {
//            var product = _context.Products
//                .Include(p => p.ProductImages)
//                .FirstOrDefault(p => p.Id == id);
//            if(product == null) {
//                return NotFound();
//            }
//            ProductVm productVm = new()
//            {
//                Product = product,
//                RelatedProducts = _context.Products
//                    .Where(p => p.CategoryId == product.CategoryId && p.Id != id)
//                    .Take(4)
//                    .ToList()
//            };
//            return View(productVm);
//        }
//    }
//}
