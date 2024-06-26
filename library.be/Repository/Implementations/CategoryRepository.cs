using library.be.BusinessException;
using library.be.Data;
using library.be.Models;
using library.be.Repository.Inteface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace library.be.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)  
        {
            _db = db;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category =await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(category is null)
            {
                throw new NoDataFoundException();
            }
            _db.Categories.Remove(category);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {   
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var res= await (_db.Categories
                               .Where(x => x.Id == id)
                               .Select( x => new Category
                               {
                                   Id = x.Id,
                                   Name = x.Name,   
                               }).AsNoTracking().FirstOrDefaultAsync());
          
            return res;
        }

      
        public async Task<int> UpdateOrCreateCategory(Category category)
        {
            var cate = _db.Categories.FirstOrDefault(x => x.Id == category.Id) ?? new Category();
            cate.Id = category.Id;
            cate.Name = category.Name;
            if(cate.Id == 0)
            {
                cate.CreatedDate = DateTime.Now;
                _db.Categories.Add(cate);
            }
            else
            {
                cate.UpdateDate= DateTime.Now;
            }
            return await _db.SaveChangesAsync();
        }
    }
}
