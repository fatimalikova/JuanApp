using JuanApp.Data;
using JuanApp.Models;
using JuanApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace JuanApp.Services
{
    // Business/Services/BasketService.cs
    public class BasketService 
    {
        private readonly JuanDbContext _context;

        public BasketService(JuanDbContext context)
        {
            _context = context;
        }

        public async Task<List<BasketItemVm>> GetBasketFromCookieAsync(string? cookieValue)
        {
            if (string.IsNullOrEmpty(cookieValue))
                return new List<BasketItemVm>();

            return System.Text.Json.JsonSerializer.Deserialize<List<BasketItemVm>>(cookieValue)
                   ?? new List<BasketItemVm>();
        }

        public async Task<List<BasketItemVm>> AddToBasketAsync(Guid productId, string? cookieValue)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new NotFoundException($"Product {productId} not found");

            var basketItems = await GetBasketFromCookieAsync(cookieValue);

            var existItem = basketItems.FirstOrDefault(b => b.ProductId == productId);
            if (existItem == null)
            {
                basketItems.Add(new BasketItemVm
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.DiscountPercentage > 0
                                       ? product.Price * (100 - product.DiscountPercentage) / 100
                                       : product.Price,
                    Count = 1,
                    MainImageUrl = product.MainImageUrl
                });
            }
            else
            {
                existItem.Count++;
            }

            return basketItems;
        }

        public async Task SyncToDbAsync(string username, Guid productId)
        {
            var user = await _context.Users
                .Include(u => u.BasketItems)
                .FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null) return;

            var existItem = user.BasketItems.FirstOrDefault(b => b.ProductId == productId);
            if (existItem == null)
            {
                _context.BasketItems.Add(new BasketItem
                {
                    ProductId = productId,
                    Count = 1,
                    AppUserId = user.Id
                });
            }
            else
            {
                existItem.Count++;
            }

            await _context.SaveChangesAsync();
        }
    }

}
