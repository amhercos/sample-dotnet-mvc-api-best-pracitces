using System.ComponentModel.DataAnnotations;

namespace MvcApi.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
