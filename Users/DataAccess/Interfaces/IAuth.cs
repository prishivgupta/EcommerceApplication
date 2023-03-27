using Products.Models;

namespace Users.DataAccess.Interfaces
{
    public interface IAuth
    {
        public UserDTO LoginUser(UserDTO user);

        public Task<UserDTO> RegisterUser(Tuser user);
    }
}
