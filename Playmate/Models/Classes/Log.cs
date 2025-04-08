using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string LogLevel { get; set; } // Example: Info, Warning, Error

        public DateTime Timestamp { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}