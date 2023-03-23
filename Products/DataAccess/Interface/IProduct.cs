using Products.Models;

namespace Products.DataAccess.Interface
{
    public interface IProduct
    {
        public Task<List<Tproduct>> AddProduct(Tproduct product);

        public Task<List<Tproduct>> UpdateProduct(Tproduct product);

        public Task<List<Tproduct>> GetAllProducts();

        public Task<string> DeleteProduct(int id);

        public Task<Tproduct> GetProductById(int id);
    }
}
