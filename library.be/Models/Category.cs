using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace library.be.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50, ErrorMessage = "Name must be 0 - 50 characters")]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }

    }
}
