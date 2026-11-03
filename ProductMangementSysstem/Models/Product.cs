using System.ComponentModel.DataAnnotations;

namespace ProductMangementSysstem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
