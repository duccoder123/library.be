using library.be.Models;

namespace library.be.Repository.Inteface
{
    public interface ICategoryRepository 
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetCategoryById(int id);
        Task<int> DeleteCategory(int id);
        Task<int> UpdateOrCreateCategory(Category category);

    }
}
