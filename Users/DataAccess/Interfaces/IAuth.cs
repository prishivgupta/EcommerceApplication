namespace Users.DataAccess.Interfaces
{
    public interface IAuth
    {
        public UserDTO LoginUser(UserDTO user);
    }
}
