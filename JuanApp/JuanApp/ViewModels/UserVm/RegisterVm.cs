using System.ComponentModel.DataAnnotations;

namespace JuanApp.ViewModels.UserVm
{
    public class RegisterVm
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [MinLength(4)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
