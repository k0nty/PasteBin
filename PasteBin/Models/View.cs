using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasteBin.Models
{
    public class View
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? ViewID { get; set; }
        public string? PasteID { get; set;} 
        public string? UserID { get; set;}
        public Pastes? Pastes{ get; set;}

        [ForeignKey("User")]
        public string? CurrentUserID { get; set; }
        public User? User { get; set; }
    }
}
