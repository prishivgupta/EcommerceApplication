using Microsoft.EntityFrameworkCore;
using Products.DataAccess;
using Products.DataAccess.Interface;
using Products.Models;

namespace Products.Repositories
{
    public class CategoryRepository : ICategory
    {

        private readonly EcommerceContext _ecommerceContext;

        public CategoryRepository (EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<List<Tcategory>> AddCategory(Tcategory category)
        {
            _ecommerceContext?.Tcategories.AddAsync(category);
            _ecommerceContext?.SaveChangesAsync();
            return await _ecommerceContext.Tcategories.ToListAsync();
        }

        public async Task<string> DeleteCategory(int id)
        {
            var category = await _ecommerceContext.Tcategories.FindAsync(id);

            if (category != null)
            {
                _ecommerceContext.Tcategories.Remove(category);
                _ecommerceContext?.SaveChangesAsync();
                return "Deleted Successfully";
            }
            else
            {
                return "Record Not Found";
            }
        }

        public async Task<List<Tcategory>> GetAllCategories()
        {
            return await _ecommerceContext.Tcategories.ToListAsync();
        }

        public async Task<Tcategory> GetCategoryById(int id)
        {
            var category = await _ecommerceContext.Tcategories.Where(j => j.CategoryId == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<List<Tcategory>> UpdateCategory(Tcategory category)
        {
            var c = await _ecommerceContext.Tcategories.FindAsync(category.CategoryId);

            if (c != null)
            {
                c.CategoryName = category.CategoryName;

                await _ecommerceContext.SaveChangesAsync();
            }

            _ecommerceContext.SaveChangesAsync();
            return await _ecommerceContext.Tcategories.ToListAsync();
        }
    }
}
