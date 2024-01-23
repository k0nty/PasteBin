using System.ComponentModel.DataAnnotations.Schema;

namespace PasteBin.Models
{
    public class View
    {
        public string? ViewID { get; set; }
        public string? PasteID { get; set;}
        public string? UserID { get; set;}
        public DateTime? ViewedAt { get; set;}
        public Pastes? Pastes{ get; set;}

        [ForeignKey("User")]
        public int? CurrentUserID { get; set; }
        public User? User { get; set; }
    }
}
