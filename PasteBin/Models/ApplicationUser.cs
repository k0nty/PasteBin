using Microsoft.AspNetCore.Identity;

namespace PasteBin.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? NickName { get; set; } 
        public User? User { get; set; }
    }
}
