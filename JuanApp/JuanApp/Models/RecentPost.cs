using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class RecentPost : BaseEntity
    {
        public Blog Blog { get; set; }
        public Guid BlogId { get; set; }
    }
}
