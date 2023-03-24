using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.Models
{
    public class Tuser
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public int UserPhoneNumber { get; set; }

        public string UserAddress { get; set; }

        public string UserPassword { get; set; }

        public string UserRole { get; set; }

        [ForeignKey("CartId")]
        public int? CartId { get; set; }

        public virtual Tcart? Cart { get; set; }
    }
}
