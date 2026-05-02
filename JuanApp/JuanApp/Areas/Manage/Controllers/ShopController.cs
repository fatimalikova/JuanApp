//using JuanApp.Data;
//using JuanApp.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace JuanApp.Areas.Manage.Controllers
//{
//    public class ShopController(JuanDbContext _context) : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public async Task<IActionResult> Index(int? colorId, int page = 1, int pageSize = 5)
//        {
//            var query = _context.Products
//                .Include(p => p.ProductColors)
//                .Include(p => p.ProductSizes)
//                .AsQueryable();

//            //if (colorId.HasValue)
//            //    query = query.Where(p => p.ProductColors.Any(pc => pc.ColorId== colorId));

//            int totalProducts = await query.CountAsync();
//            int totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

//            var products = await query
//                .Skip((page - 1) * pageSize)
//                .Take(pageSize)
//                .ToListAsync();

//            var vm = new ShopVm
//            {
//                Products = products,
//                Colors = await _context.Colors.ToListAsync(),
//                Sizes = await _context.Sizes.ToListAsync(),
//                CurrentPage = page,
//                TotalPages = totalPages,
//                TotalProducts = totalProducts,
//                PageSize = pageSize,
//                ColorId = colorId
//            };

//            return View(vm);
//        }
//    }
//}
