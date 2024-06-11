using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServerCopy2.Models
{
    public class ApplicationUser : IdentityUser
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
    }
}
