using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
