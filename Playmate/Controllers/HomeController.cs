using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Playmate.Models.Classes;
using System.Data.Entity;
using Playmate.Models; // Context sınıfınızın olduğu namespace

namespace Playmate.Controllers
{
    public class HomeController : Controller
    {
        private Context c = new Context(); 

        public ActionResult Index()
        {
  
            List<int> favoritedProductIds = new List<int>();
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];

                favoritedProductIds = c.Favorites
                                       .Where(f => f.UserId == userId)
                                       .Select(f => f.ProductId)
                                       .ToList();
            }

            ViewBag.FavoritedProductIds = favoritedProductIds;



            var allProducts = c.Products
                               .Include(p => p.User)
                               .ToList();

            var featuredProducts = allProducts.OrderBy(p => Guid.NewGuid()).Take(4).ToList();


            var newArrivals = allProducts.OrderByDescending(p => p.ProductId).Take(8).ToList();

            ViewBag.NewArrivals = newArrivals;

            return View(featuredProducts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                c.Dispose(); 
            }
            base.Dispose(disposing);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}