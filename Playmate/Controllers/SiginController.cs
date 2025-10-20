using Playmate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playmate.Controllers
{
    public class SiginController : Controller
    {

        private readonly Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string fullname, string email, string password, string confirm)
        {
            // Şifreler eşleşiyor mu?
            if (password != confirm)
            {
                ViewBag.Error = "Şifreler eşleşmiyor.";
                return View();
            }

            // Aynı email ile daha önce kayıt olunmuş mu?
            var existingUser = c.Users.FirstOrDefault(u => u.Email == email);
            if (existingUser != null)
            {
                ViewBag.Error = "Bu e-posta adresiyle daha önce kayıt olunmuş.";
                return View();
            }

            // Yeni kullanıcı oluştur
            var user = new User
            {
                FullName = fullname,
                Email = email,
                Password = password
            };

            c.Users.Add(user);
            c.SaveChanges();

            // Kayıt sonrası oturum başlat
            Session["UserId"] = user.UserId;
            Session["UserName"] = user.FullName;

            return RedirectToAction("Index", "User");
        }
    }
}