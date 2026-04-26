using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductColor> ProductColors { get; set; }

    }
}
