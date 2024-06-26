
using library.be.Repository.Inteface;
using System.Security.Claims;

namespace library.be.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IProductRepository _productRepo;
        public BorrowService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task BorrowAsync(int bookId, int amount)
        {
           var book = await _productRepo.GetProductById(bookId);
            if (book is null && book.Amount == 0) { 
                
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
