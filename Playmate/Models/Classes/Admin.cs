using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}