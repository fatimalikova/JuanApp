using JuanApp.Attributes;
using JuanApp.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped] // Bu property db-de saklanmaz, sadece dosya yükleme işlemi için kullanılır
        [FileLength(2)]
        [FileTypes("image/jpeg", "image/png", "image/gif")]
        public IFormFile File { get; set; }
    }
}
