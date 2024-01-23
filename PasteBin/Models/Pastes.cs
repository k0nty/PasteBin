﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PasteBin.Models
{
    public class Pastes
    {
        public string? PastesID {  get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpirationData { get; set; }

        public View? View { get; set; }

        [ForeignKey("User")]
        public int? CurrentUserID { get; set; }
        public User? User { get; set; }
    }
}
