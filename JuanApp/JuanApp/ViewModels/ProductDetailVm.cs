using JuanApp.Models;

namespace JuanApp.ViewModels
{
    public class ProductDetailVm
    {
        public Product Product { get; set; } = null!;
        public List<Product> RelatedProducts { get; set; } = new();
    }
}
