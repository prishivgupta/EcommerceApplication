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
            try
            {
                _ecommerceContext?.Tcategories.AddAsync(category);
                await _ecommerceContext?.SaveChangesAsync();
                return await _ecommerceContext.Tcategories.ToListAsync();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<string> DeleteCategory(int id)
        {
            try
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<Tcategory>> GetAllCategories()
        {
            try
            {
                return await _ecommerceContext.Tcategories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Tcategory> GetCategoryById(int id)
        {
            try
            {
                var category = await _ecommerceContext.Tcategories.Where(j => j.CategoryId == id).FirstOrDefaultAsync();
                return category;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<Tcategory>> UpdateCategory(Tcategory category)
        {
            try
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
