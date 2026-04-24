using JuanApp.Models;

namespace JuanApp.ViewModels
{
    public class HomeVm
    {
        public List<Slider> Sliders { get; set; }
        public List<Product> Products { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Product> NewProducts { get; set; }
    }
}
