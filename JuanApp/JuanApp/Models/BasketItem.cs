using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class BasketItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
