using JuanApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace JuanApp.Controllers
{
    public class BlogController(JuanDbContext _context) : Controller
    {

        public IActionResult Detail(Guid id)
        {
            var blog = _context.Blogs
                .FirstOrDefault(b => b.Id == id);

            if (blog == null)
                return NotFound();

            return View(blog);
        }

        public IActionResult BlogModal(Guid id)
        {
            var blog = _context.Blogs
                .FirstOrDefault(b => b.Id == id);

            if (blog == null)
                return NotFound();

            return PartialView("_BlogModalPartialView", blog);
        }
    }
}
