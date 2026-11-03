using System.ComponentModel.DataAnnotations;

namespace ProductMangementSysstem.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(params string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is not IFormFile file)
                return ValidationResult.Success;

            var extension =
                Path.GetExtension(file.FileName)
                    .ToLowerInvariant();

            if (!_extensions.Contains(extension))
            {
                return new ValidationResult(
                    $"Allowed extensions: {string.Join(", ", _extensions)}");
            }

            return ValidationResult.Success;
        }
    }
}
