using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            return View(Session["ListOfProducts"]);
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            var id = Request["addtocart"];
            int index = int.Parse(id);

            if(id != null)
            {

                List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
                tmpList[index].ReduceStockCount();
                Session["ListOfProducts"] = tmpList;

                Cart tmpCart = (Cart)Session["Cart"];
                tmpCart.ProductList.Add(tmpList[index]);
                Session["Cart"] = tmpCart;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetProduct(int id)
        {
            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            Product tmpProduct = tmpList[id];

            return View(tmpProduct);
        }
    }
}