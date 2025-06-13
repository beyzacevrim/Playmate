using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playmate.Controllers
{
    public class BasketController : Controller
    {
     
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            ViewBag.UserName = Session["UserName"];
            return View();
        }
    }
}