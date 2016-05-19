using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerApplication.Models;
using PagedList;
using PagedList.Mvc;


namespace CustomerApplication.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int? page)
        {
            ProductsContext productsContext = new ProductsContext();
            List<Products> ProductList = productsContext.ProductList.ToList();

            Dictionary<int, byte[]> ProductImages = new Dictionary<int, byte[]>();
            foreach (Products pro in ProductList)
            {
                ProductDetails ProductDetails = productsContext.ProductDetailsList.Single(img => img.ProductId == pro.ProductId);
                ProductImages.Add(pro.ProductId, ProductDetails.ProductImage);
            }
            ViewBag.Images = ProductImages;

            return View(productsContext.ProductList.ToList().ToPagedList(page ?? 1, 16));
        }


        public ActionResult Details(int id)
        {

            ProductsContext productsContext = new ProductsContext();
            ProductDetails productDetails = productsContext.ProductDetailsList.Single(details => details.ProductId == id);
            Products products = productsContext.ProductList.Single(details => details.ProductId == id);
            ViewBag.Name = products.ProductName;
            ViewBag.Description = products.ProductDescription;
            return View(productDetails);
        }


        public ActionResult AddToCart(int id)
        {
            if (Session["Items"] == null)
            {
                Session["Items"] = id.ToString();
            }
            else
            {
                Session["Items"] = Session["Items"].ToString() + ";" + id;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Cart()
        {
            string[] ProductIds = Session["Items"].ToString().Split(';');
            ProductsContext productsContext = new ProductsContext();
            List<ProductDetails> ProductDetailsList = new List<ProductDetails>();
            Dictionary<int, string> productNames = new Dictionary<int, string>();
            foreach (string productId in ProductIds)
            {
                int Pid = Convert.ToInt32(productId);
                ProductDetailsList.Add(productsContext.ProductDetailsList.Single(id => id.ProductId == Pid));
                Products product = productsContext.ProductList.Single(id => id.ProductId == Pid);
                productNames.Add(Pid, product.ProductName);
            }

            ViewBag.ProductNames = productNames;
            return View(ProductDetailsList);
        }

        //[HttpPost]
        //public ActionResult Cart()
        //{

        //    return View();
        //}

    }
}
