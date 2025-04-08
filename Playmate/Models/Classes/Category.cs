using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Playmate.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}