using System.ComponentModel.DataAnnotations;

namespace PasteBin.Models
{
    public class Users: ApplicationUser
    {
        public string? UserID { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }

        public ICollection<Pastes> userPastes { get; set; }
        public ICollection<Views> userViews { get; set; }
    }
}
