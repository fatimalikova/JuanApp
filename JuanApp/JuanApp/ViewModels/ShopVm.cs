using JuanApp.Models;

namespace JuanApp.ViewModels
{
    public class ShopVm
    {
        public List<Product> Products { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Color> Colors { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalProducts { get; set; }
        public int? ColorId { get; set; }
    }
}
