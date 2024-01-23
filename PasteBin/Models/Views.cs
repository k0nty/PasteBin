namespace PasteBin.Models
{
    public class Views
    {
        public string? ViewID { get; set; }
        public string? PasteID { get; set;}
        public string? UserID { get; set;}
        public DateTime? ViewedAt { get; set;}

        public ICollection<Users> viewsUsers { get; set; }
        public ICollection<Pastes> viewsPastes { get; set; }
    }
}
