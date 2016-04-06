using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {

            return View(Session["Cart"]);
        }

        [HttpPost]
        public ActionResult AddToCart()
        {

            var id = Request["addtocart"];
            int index = int.Parse(id);

            if (id != null)
            {

                List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
                tmpList[index].ReduceStockCount();
                Session["ListOfProducts"] = tmpList;

                Cart tmpCart = (Cart)Session["Cart"];
                tmpCart.AddProduct(tmpList[index]);
                Session["Cart"] = tmpCart;
            }

            return RedirectToAction("../Default/Index");
        }
    }
}