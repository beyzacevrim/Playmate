using System.Data.Entity;  
using System.Linq;
using System.Web.Mvc;
using Playmate.Models.Classes;
using Playmate.Models.ViewModels;

namespace Playmate.Controllers
{
    public class ShopController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            var products = c.Products
                            .Include(p => p.User)
                            .Include(p => p.Category)
                            .OrderByDescending(p => p.ProductId)
                            .ToList();


            var categories = c.Categories.ToList();

            var viewModel = new UserProfileViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(viewModel);
        }
    }
}
