using Microsoft.AspNetCore.Identity;

namespace library.be.Domain
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
        {
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
