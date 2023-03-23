using Microsoft.EntityFrameworkCore;
using Products.DataAccess;
using Products.DataAccess.Interface;
using Products.Models;

namespace Products.Repositories
{
    public class ProductRepository : IProduct
    {

        private readonly EcommerceContext _ecommerceContext;

        public ProductRepository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<List<Tproduct>> AddProduct(Tproduct product)
        {
            try {
                _ecommerceContext?.Tproducts.AddAsync(product);
                _ecommerceContext?.SaveChangesAsync();
                return await _ecommerceContext.Tproducts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<string> DeleteProduct(int id)
        {
            try
            {
                var product = await _ecommerceContext.Tproducts.FindAsync(id);

                if (product != null)
                {
                    _ecommerceContext.Tproducts.Remove(product);
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

        public async Task<List<Tproduct>> GetAllProducts()
        {
            try
            {
                return await _ecommerceContext.Tproducts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Tproduct> GetProductById(int id)
        {
            try
            {
                var product = await _ecommerceContext.Tproducts.Where(j => j.ProductId == id).Include(c => c.Category).FirstOrDefaultAsync();
                return product;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            
        }

        public async Task<List<Tproduct>> UpdateProduct(Tproduct product)
        {
            try
            {
                var p = await _ecommerceContext.Tproducts.FindAsync(product.CategoryId);

                if (p != null)
                {
                    p.ProductName = product.ProductName;
                    p.ProductPrice = product.ProductPrice;
                    p.ProductDescription = product.ProductDescription;
                    p.ProductQuantity = product.ProductQuantity;
                    p.ProductDiscountedPrice = product.ProductDiscountedPrice;
                    p.Rating = product.Rating;
                    p.ProductImages = product.ProductImages;
                    p.CategoryId = product.CategoryId;

                    await _ecommerceContext.SaveChangesAsync();
                }

                _ecommerceContext.SaveChangesAsync();
                return await _ecommerceContext.Tproducts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
