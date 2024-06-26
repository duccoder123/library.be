using library.be.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.be.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; } 
        public int Amount { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        public DateTime BorrowDate { get; set; }    
        public DateTime ReturnDate { get; set; }

      
    }
}
