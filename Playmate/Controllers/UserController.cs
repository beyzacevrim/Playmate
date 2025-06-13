using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Playmate.Models.Classes;
using Playmate.Models.ViewModels;

namespace Playmate.Controllers
{
    public class UserController : Controller
    {
        
        Context c = new Context();
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            int userId = (int)Session["UserId"];
            var user = c.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            var userProducts = c.Products.Where(p => p.UserId == userId).ToList();

            var model = new UserProfileViewModel
            {
                User = user,
                Products = userProducts
            };

            return View(model);
        }

    }
}
