namespace PasteBin.Models
{
    public class Pastes
    {
        public string? PastesID {  get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpirationData { get; set; }
    }
}
