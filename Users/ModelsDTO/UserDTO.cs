using System.Security.Policy;

namespace Users
{
    public class UserDTO
    {
        public int? UserId { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

        public int? UserPhoneNumber { get; set; }

        public string? UserAddress { get; set; }

        public string UserPassword { get; set; }

        public string? UserRole { get; set; }

        public string? Message { get; set; }

        public string? Token { get; set; }
    }
}
