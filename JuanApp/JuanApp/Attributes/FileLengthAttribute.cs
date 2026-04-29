using System.ComponentModel.DataAnnotations;

namespace JuanApp.Attributes
{
    public class FileLengthAttribute: ValidationAttribute
    {
        public int Length { get; set; }
        public FileLengthAttribute(int length)
        {
            Length = length;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            List<IFormFile> files = new List<IFormFile>();
            if( value is List<IFormFile> fileList)
            {
                files = fileList;
            }
            else if (value is IFormFile file)
            {
                files.Add(file);
            }

            foreach (var file in files)
            {
                if (file.Length > Length * 1024 * 1024)
                {
                    return new ValidationResult($"File size must be less than {Length}MB.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
