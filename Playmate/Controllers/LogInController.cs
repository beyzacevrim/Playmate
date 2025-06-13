using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Playmate.Models.Classes;

namespace Playmate.Controllers
{
    public class LogInController : Controller
    {

        private readonly Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            var user = c.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.FullName; 
                return RedirectToAction("Index", "User");
            }

            ViewBag.Error = "Email veya şifre yanlış.";
            return View();
        }
        public ActionResult LogOut()
        {

            Session.Clear(); 
            Session.Abandon(); 

            
            FormsAuthentication.SignOut();

            
            return RedirectToAction("Index", "LogIn");
            
        }
    }
}