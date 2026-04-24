using JuanApp.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string MainImageUrl { get; set; }
        public bool InStock { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public bool IsNew { get; set; }

    }
}
