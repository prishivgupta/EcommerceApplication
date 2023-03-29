using Microsoft.EntityFrameworkCore;
using Products.DataAccess;
using Products.Models;
using Users.DataAccess.Interfaces;

namespace Users.Repositories
{
    public class UserRepository : IUser
    {
        private readonly EcommerceContext _ecommerceContext;

        public UserRepository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<List<Tuser>> AddUser(Tuser user)
        {
            try
            {
                var cart = new Tcart()
                {
                    Discount = 0,
                    TotalCost = 0,
                };

                await _ecommerceContext.Tcarts.AddAsync(cart);
                await _ecommerceContext?.SaveChangesAsync();

                var newCart = _ecommerceContext.Tcarts.OrderByDescending(a => a.CartId).First();
                user.CartId = newCart.CartId;

                _ecommerceContext?.Tusers.AddAsync(user);
                await _ecommerceContext?.SaveChangesAsync();
                return await _ecommerceContext.Tusers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> DeleteUser(int id)
        {
            try
            {
                var user = await _ecommerceContext.Tusers.FindAsync(id);

                if (user != null)
                {
                    _ecommerceContext.Tusers.Remove(user);
                    _ecommerceContext?.SaveChangesAsync();
                    return "Deleted Successfully";
                }
                else
                {
                    return "Record Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<List<Tuser>> GetAllUsers()
        {
            try
            {
                return await _ecommerceContext.Tusers.Include(p => p.Cart).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Tuser> GetUserById(int id)
        {
            try
            {
                var user = await _ecommerceContext.Tusers.Where(j => j.UserId == id).Include(p => p.Cart).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

        public async Task<List<Tuser>> UpdateUser(Tuser user)
        {
            try
            {
                var p = await _ecommerceContext.Tusers.FindAsync(user.UserId);

                if (p != null)
                {
                    p.UserName = user.UserName;
                    p.UserPhoneNumber = user.UserPhoneNumber;
                    p.UserEmail = user.UserEmail;
                    p.UserAddress = user.UserAddress;
                    p.UserRole = user.UserRole;
                    p.CartId = user.CartId;

                    await _ecommerceContext.SaveChangesAsync();
                }

                await _ecommerceContext.SaveChangesAsync();
                return await _ecommerceContext.Tusers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
