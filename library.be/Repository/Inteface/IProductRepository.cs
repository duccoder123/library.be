using library.be.Models;

namespace library.be.Repository.Inteface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<int> DeleteProduct(int id);
        Task<int> CreateOrUpdateProduct(Product product);
    }
}
