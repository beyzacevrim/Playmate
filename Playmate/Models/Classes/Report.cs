using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public string ReportType { get; set; } // Example: Spam, Offensive Content, etc.

        [Required]
        public string Content { get; set; }

        [Required]
        public int ReportedById { get; set; }
        public User ReportedBy { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime ReportDate { get; set; }
    }
}