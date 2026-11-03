namespace ProductMangementSysstem.Validation
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    public class MaxFileSizeAttribute : ValidationAttribute
    {
            private readonly long _maxBytes;

            public MaxFileSizeAttribute(long maxBytes)
            {
                _maxBytes = maxBytes;
            }

            protected override ValidationResult? IsValid(
                object? value,
                ValidationContext validationContext)
            {
                if (value is not IFormFile file)
                    return ValidationResult.Success;

                if (file.Length > _maxBytes)
                {
                    return new ValidationResult(
                        $"Maximum file size is {_maxBytes / 1024 / 1024} MB.");
                }

                return ValidationResult.Success;
            }
        }
    }

