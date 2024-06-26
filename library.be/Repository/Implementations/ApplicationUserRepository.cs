using library.be.Data;
using library.be.Domain;
using library.be.Repository.Inteface;

namespace library.be.Repository.Implementations
{
    public class ApplicationUserRepository :IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
