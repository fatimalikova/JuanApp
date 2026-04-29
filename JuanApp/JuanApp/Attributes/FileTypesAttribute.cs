using System.ComponentModel.DataAnnotations;

namespace JuanApp.Attributes
{
    public class FileTypesAttribute : ValidationAttribute
    {
        public string[] Types { get; set; }
        public FileTypesAttribute(params string[] types)
        {
            Types = types;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            List<IFormFile> files = new List<IFormFile>();
            if (value is List<IFormFile> fileList)
            {
                files = fileList;
            }
            else if (value is IFormFile file)
            {
                files.Add(file);
            }
            foreach (var file in files)
            {
                
                if (!Types.Contains(file.ContentType))
                {
                    return new ValidationResult($"Only the following file types are allowed: {string.Join(", ", Types)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
