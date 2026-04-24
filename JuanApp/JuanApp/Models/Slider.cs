using JuanApp.Models.Common;

namespace JuanApp.Models
{
    public class Slider : BaseEntity
    {
        public string Etiket { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
    }
}
