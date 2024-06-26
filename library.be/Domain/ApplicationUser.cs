using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library.be.Domain
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
        }

        [Column("Name")]
        public string Name { get; set; }
        [Column("Active")]
        public bool Active { get; set; } = false;
        [Column("LastLogin", TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Column("UpdateDate", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
    }
}
