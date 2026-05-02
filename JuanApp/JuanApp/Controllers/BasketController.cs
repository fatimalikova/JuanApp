using JuanApp.Data;
using JuanApp.Models;
using JuanApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JuanApp.Controllers
{
    public class BasketController(JuanDbContext _context) : Controller
    {
        public IActionResult AddBasket(Guid id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            List<BasketItemVm> basketItems;
            var existBasket = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(existBasket))
            {
                basketItems = new List<BasketItemVm>();

            }
            else
            {
                basketItems = System.Text.Json.JsonSerializer.Deserialize<List<BasketItemVm>>(existBasket);
            }
            var existBasketItem = basketItems.FirstOrDefault(b => b.ProductId == id);
            if (existBasketItem == null)
            {
                basketItems.Add(new BasketItemVm
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.DiscountPercentage > 0 ? product.Price * (100 - product.DiscountPercentage) / 100 : product.Price,
                    Count = 1,
                    MainImageUrl = product.MainImageUrl
                });
            }
            else
            {
                existBasketItem.Count++;
            }
            if (User.Identity.IsAuthenticated)
            {
                var user = _context.Users
                    .Include(u => u.BasketItems)
                    .FirstOrDefault(u => u.UserName == User.Identity.Name);
                var userBasketItem = user.BasketItems.FirstOrDefault(b => b.ProductId == id);
                if (userBasketItem == null)
                {
                    _context.BasketItems.Add(new BasketItem
                    {
                        ProductId = product.Id,
                        Count = 1,
                        AppUserId = user.Id
                    });

                }
                else
                {
                    userBasketItem.Count++;
                }
                _context.SaveChanges();
            }
            Response.Cookies.Append("basket", System.Text.Json.JsonSerializer.Serialize(basketItems));
            return PartialView("_BasketPartial", new List<BasketItemVm>());
            
        }
    }
}
