using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopBackEnd.Models.DataModels
{
    [Table("AppUsers")]

    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        ICollection<Cart> Carts { get; set; }

        ICollection<Order> Orders { get; set; }

    }
}
