using Azure;
using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class ProductColor : BaseEntity
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Color Color { get; set; }
        public Guid ColorId { get; set; }
    }
}
