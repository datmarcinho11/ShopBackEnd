using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopBackEnd.Models.DataModels
{
    [Table("AppRoles")]

    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
