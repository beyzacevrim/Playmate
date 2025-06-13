using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Playmate.Models.Classes; 
using System.Data.Entity; 

using Playmate.Models; 


namespace Playmate.Controllers
{
    public class FavorilerController : Controller
    {

        private Context c = new Context(); 

        
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            int userId = (int)Session["UserId"]; 

            var userFavorites = c.Favorites
                                     .Include(f => f.Product) 
                                     .Include(f => f.User)   
                                     .Where(f => f.UserId == userId)
                                     .ToList();

            ViewBag.UserName = Session["UserName"];

            return View(userFavorites);
        }

        [HttpPost]
        public JsonResult AddFavorite(int productId) 
        {
            if (Session["UserId"] == null)
            {
                return Json(new { success = false, message = "Lütfen oturum açın." });
            }

            int userId = (int)Session["UserId"];

          
            bool alreadyFavorited = c.Favorites.Any(f => f.UserId == userId && f.ProductId == productId);

            if (alreadyFavorited)
            {
                return Json(new { success = false, message = "Bu ürün zaten favorilerinizde." });
            }

            
            Favorite newFavorite = new Favorite
            {
                UserId = userId,
                ProductId = productId,
            };

            try
            {
                c.Favorites.Add(newFavorite); 
                c.SaveChanges();

                return Json(new { success = true, message = "Ürün favorilere eklendi." });
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Favoriye ekleme hatası: " + ex.Message);
                return Json(new { success = false, message = "Favoriye eklerken bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult RemoveFavorite(int productId) 
        {
            if (Session["UserId"] == null)
            {
                return Json(new { success = false, message = "Lütfen oturum açın." });
            }

            int userId = (int)Session["UserId"];

            
            var favoriteToRemove = c.Favorites 
                                     .FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);

            if (favoriteToRemove == null)
            {
                return Json(new { success = false, message = "Bu ürün favorilerinizde bulunamadı." });
            }

            try
            {
                c.Favorites.Remove(favoriteToRemove); 
                c.SaveChanges(); 

                return Json(new { success = true, message = "Ürün favorilerden kaldırıldı." });
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Favoriden çıkarma hatası: " + ex.Message);
                return Json(new { success = false, message = "Favoriden kaldırırken bir hata oluştu: " + ex.Message });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                c.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}