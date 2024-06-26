using library.be.BusinessException;
using library.be.Data;
using library.be.Models;
using library.be.Repository.Inteface;
using Microsoft.EntityFrameworkCore;

namespace library.be.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<int> CreateOrUpdateProduct(Product model)
        {
            var product = _db.Products.FirstOrDefault(x=> x.Id == model.Id) ?? new Product();
            product.Id = model.Id;
            product.Title = model.Title;
            product.Description = model.Description;    
            product.Price = model.Price;
            product.Amount = model.Amount;
            product.Author = model.Author;
            product.CategoryId = model.CategoryId;
            product.ISBN = model.ISBN;
            if (product.Id == 0) {
                _db.Products.Add(product);
            }
           
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int id)
        {
           var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product is null) {
                throw new NoDataFoundException();
            }
            _db.Remove(product);
            return await _db.SaveChangesAsync();    
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var res = await (_db.Products
                                 .Where(x => x.Id == id)
                                 .Select(x => new Product
                                 {
                                     Id = x.Id,
                                     Author = x.Author,
                                     Description = x.Description,
                                     CategoryId = x.CategoryId,
                                     ISBN = x.ISBN,
                                     Title = x.Title,
                                     Price = x.Price,
                                     Amount = x.Amount,
                                 }).AsNoTracking().FirstOrDefaultAsync());
            return res; 
        }
    }
}
