using System.ComponentModel.DataAnnotations;

namespace JuanApp.Areas.Manage.ViewModels
{
    public class AdminLoginVm
    {
        [Required]
        [MinLength(2)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
