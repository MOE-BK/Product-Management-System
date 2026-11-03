using Microsoft.AspNetCore.Mvc.Rendering;
using ProductMangementSysstem.Validation;
using System.ComponentModel.DataAnnotations;

namespace ProductMangementSysstem.ViewModel
{
    public class ProductViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string? Description { get; set; }
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")]
        public IFormFile? Cover { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
            = new List<SelectListItem>();


    }
}
