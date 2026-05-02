using JuanApp.Data;
using JuanApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JuanApp.Services
{
    public class LayoutService(JuanDbContext context,IHttpContextAccessor httpContextAccessor)
    {
        public Dictionary<string, string> GetSettings()
        {
            return context.Settings.ToDictionary(x => x.Key, x => x.Value);
        }

        public List<BasketItemVm> GetBasketItems()
        {
            //List<BasketItemVm> basketItems;
            //var existBasket = context.Users
            //    .Where(u => u.UserName == "admin")
            //    .Select(u => u.BasketItems)
            //    .FirstOrDefault();
            //if (existBasket == null)
            //{
            //    basketItems = new List<BasketItemVm>();
            //}
            //else
            //{
            //    basketItems = existBasket.Select(b => new BasketItemVm
            //    {
            //        ProductId = b.ProductId,
            //        Count = b.Count,
            //        Name = context.Products.Where(p => p.Id == b.ProductId).Select(p => p.Name).FirstOrDefault(),
            //        Price = context.Products.Where(p => p.Id == b.ProductId).Select(p => p.DiscountPercentage > 0 ? p.Price * (100 - p.DiscountPercentage) / 100 : p.Price).FirstOrDefault(),
            //        MainImageUrl = context.Products.Where(p => p.Id == b.ProductId).Select(p => p.MainImageUrl).FirstOrDefault()
            //    }).ToList();
            //}
            //return basketItems;
            List<BasketItemVm> basketItems;
            var basketStr = httpContextAccessor.HttpContext.Request.Cookies["basket"];
            if(string.IsNullOrEmpty(basketStr)  )
            {
                basketItems = new List<BasketItemVm>();
            }
            else
            {
                basketItems = System.Text.Json.JsonSerializer.Deserialize<List<BasketItemVm>>(basketStr);
            }

            if(httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = context.Users
                    .Include(u=> u.BasketItems)
                    .ThenInclude(b => b.Product)
                    .FirstOrDefault(u => u.UserName == httpContextAccessor.HttpContext.User.Identity.Name);
                foreach (var item in user.BasketItems)
                {
                    var existBasketItemVm = basketItems.FirstOrDefault(b => b.ProductId == item.ProductId);
                    if(existBasketItemVm is null)
                    {
                        basketItems.Add(new BasketItemVm
                        {
                            ProductId = item.ProductId,
                            Count = item.Count,
                            Name = item.Product.Name,
                            Price = item.Product.DiscountPercentage > 0 ? item.Product.Price * (100 - item.Product.DiscountPercentage) / 100 : item.Product.Price,
                            MainImageUrl = item.Product.MainImageUrl
                        });
                    }
                    else
                    {
                        existBasketItemVm.Price = item.Product.DiscountPercentage > 0 ? item.Product.Price * (100 - item.Product.DiscountPercentage) / 100 : item.Product.Price;
                        existBasketItemVm.Name = item.Product.Name;
                        existBasketItemVm.MainImageUrl = item.Product.MainImageUrl;
                        existBasketItemVm.Count += item.Count;
                    }
                }
                
            }
            return basketItems;

        }
    }
}
