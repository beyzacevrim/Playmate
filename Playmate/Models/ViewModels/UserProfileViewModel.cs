using Playmate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Playmate.Models.ViewModels
{
    public class UserProfileViewModel
    {
 
        public User User { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }
    }
}