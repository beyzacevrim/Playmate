using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Playmate.Models.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public string Role { get; set; } // "Donor" veya "Recipient"

        public ICollection<Product> Products { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Donation> Donations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }

}