using System.ComponentModel.DataAnnotations;

namespace PasteBin.Models
{
    public class User: ApplicationUser
    {
        public string? UserID { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
    }
}
