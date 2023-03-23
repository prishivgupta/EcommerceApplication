using Products.Models;

namespace Products.DataAccess.Interface
{
    public interface ICategory
    {
        public Task<List<Tcategory>> AddCategory(Tcategory category);

        public Task<List<Tcategory>> UpdateCategory(Tcategory category);

        public Task<List<Tcategory>> GetAllCategories();

        public Task<string> DeleteCategory(int id);

        public Task<Tcategory> GetCategoryById(int id);
    }
}
