using System.ComponentModel.DataAnnotations.Schema;

namespace library.be.Models
{
    public class RepoItem
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int BorrowingId { get; set; }
    }
}
