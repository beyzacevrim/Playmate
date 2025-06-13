using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Playmate.Models.Classes;
using System.IO;
using Playmate.Models.ViewModels;

namespace Playmate.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();


        public ActionResult Index()
        {

            var products = c.Products.ToList();
            return View(products); 
        }

        public ActionResult Details(int id) 
        {

            var product = c.Products
                .Include(p => p.User)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);


            if (product == null) return HttpNotFound();


            var viewModel = new UserProfileViewModel
            {
                User = product.User,
                Products = new List<Product> { product }

            };

            return View(viewModel);
        }

        [HttpGet] 
        public ActionResult AddProduct()
        {
            
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Ürün eklemek için giriş yapmalısınız.";
                return RedirectToAction("Index", "LogIn");
            }
            ViewBag.Categories = new SelectList(c.Categories.ToList(), "CategoryId", "CategoryName");

            return View(); 
        }

        
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase productImageFile)
        {
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Ürün eklemek için giriş yapmalısınız.";
                return RedirectToAction("Index", "LogIn");
            }

           
            if (ModelState.IsValid)
            {
                
                if (productImageFile != null && productImageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(productImageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/wwwroot/image/"), fileName); 
                    productImageFile.SaveAs(path);
                    product.ProductImage = "image/" + fileName; 
                }
                else
                {
                    
                    product.ProductImage = "~/wwwroot/images/default.jpg"; 
                }

                
                product.UserId = (int)Session["UserId"];

                c.Products.Add(product);
                c.SaveChanges();

                TempData["SuccessMessage"] = "Ürün başarıyla eklendi!";
                return RedirectToAction("Index", "User"); 
            }

            ViewBag.Categories = new SelectList(c.Categories.ToList(), "CategoryId", "CategoryName");

            
            return View(product);
        }


        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            if (Session["UserId"] == null)
            {
                TempData["ErrorMessage"] = "Ürünü silmek için giriş yapmalısınız.";
                return RedirectToAction("Index", "LogIn");
            }

            var product = c.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                TempData["ErrorMessage"] = "Silinecek ürün bulunamadı.";
                return RedirectToAction("Index", "User");
            }

            if (product.UserId != (int)Session["UserId"])
            {
                TempData["ErrorMessage"] = "Bu ürünü silmeye yetkiniz yok.";
                return RedirectToAction("Index", "User");
            }

            try
            {
                if (!string.IsNullOrEmpty(product.ProductImage))
                {
                    string fullPath = Server.MapPath(product.ProductImage);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }

                c.Products.Remove(product);
                c.SaveChanges();

                TempData["SuccessMessage"] = "Ürün başarıyla silindi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ürün silinirken bir hata oluştu: " + ex.Message;
            }

            return RedirectToAction("Index", "User");
        }
    }
}