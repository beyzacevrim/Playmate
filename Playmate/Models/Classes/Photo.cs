using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime UploadDate { get; set; }
    }
}