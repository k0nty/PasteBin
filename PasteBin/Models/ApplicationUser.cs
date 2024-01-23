using Microsoft.AspNetCore.Identity;

namespace PasteBin.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name {  get; set; }
        public User? User { get; set; }
    }
}
