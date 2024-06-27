using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.be.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        [Required]
        public string ISBN { get; set; } = default!;
        [Required]
        public string Author { get; set; } = default!;
        [Required]
        public double Price { get; set; }
        [Required]
        public int Amount { get; set; }
       

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public virtual Category? Category { get; set; }

    }
}
