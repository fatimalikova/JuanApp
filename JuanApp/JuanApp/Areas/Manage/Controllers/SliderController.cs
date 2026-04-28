using JuanApp.Data;
using JuanApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanApp.Areas.Manage.Controllers
{
    public class SliderController : Controller
    {
        private readonly JuanDbContext _context;

        public SliderController(JuanDbContext context)
        {
            _context = context;
        }

        [Area("Manage")]
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }

        [Area("Manage")]
        [HttpGet]
        public async Task<IActionResult> GetSlider(Guid id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null)
            {
                return NotFound();
            }
            return Json(new
            {
                id = slider.Id,
                etiket = slider.Etiket,
                title = slider.Title,
                description = slider.Description,
                imageUrl = slider.ImageUrl,
                buttonText = slider.ButtonText,
                buttonUrl = slider.ButtonUrl
            });
        }

        [Area("Manage")]
        public IActionResult Create()
        {
            return View();
        }

        [Area("Manage")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                slider.Id = Guid.NewGuid();
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        [Area("Manage")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [Area("Manage")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Slider slider)
        {
            if (id != slider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(slider);
        }

        [Area("Manage")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [Area("Manage")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(Guid id)
        {
            return _context.Sliders.Any(e => e.Id == id);
        }
    }
}
