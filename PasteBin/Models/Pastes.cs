using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasteBin.Models
{
    public class Pastes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? PastesID {  get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpirationData { get; set; }

        public View? View { get; set; }

        [ForeignKey("User")]
        public string? CurrentUserID { get; set; }
        public User? User { get; set; }
    }
}
