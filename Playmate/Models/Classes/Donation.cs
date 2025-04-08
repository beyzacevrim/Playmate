using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        [Required]
        public DateTime DonationDate { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int DonorId { get; set; }
        public User Donor { get; set; }

        [Required]
        public int RecipientId { get; set; }
        public User Recipient { get; set; }

        [Required]
        public string DonationStatus { get; set; } // Pending, Shipped, Delivered, Canceled
    }
}