using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class ProductSize : BaseEntity
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Size Size { get; set; }
        public Guid SizeId { get; set; }
    }
}
