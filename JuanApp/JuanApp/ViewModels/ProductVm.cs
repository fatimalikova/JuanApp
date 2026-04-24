using JuanApp.Models;

namespace JuanApp.ViewModels
{
    public class ProductVm
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts{ get; set; }
    }
}
