using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.Models   // ✅ ADD THIS
{
    public class Listing
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

public DateTime CreatedAt { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}