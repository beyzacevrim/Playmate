using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string NotificationType { get; set; } // Example: Message, Donation, etc.

        public bool IsRead { get; set; }
    }
}