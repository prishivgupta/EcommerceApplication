using Products.Models;

namespace Users.DataAccess.Interfaces
{
    public interface IUser
    {
        public Task<List<Tuser>> AddUser(Tuser user);

        public Task<List<Tuser>> UpdateUser(Tuser user);

        public Task<List<Tuser>> GetAllUsers();

        public Task<string> DeleteUser(int id);

        public Task<Tuser> GetUserById(int id);

    }
}
