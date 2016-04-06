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

            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];

            if (id != null && tmpList[index].ReduceStockCount())
            { 
                
                Session["ListOfProducts"] = tmpList;

                Cart tmpCart = (Cart)Session["Cart"];
                tmpCart.AddProduct(tmpList[index]);
                Session["Cart"] = tmpCart;
            }

            return Redirect("/Default/Index");
        }

        /// <summary>
        /// Methods to use in Cart-view when adding and removing items
        /// </summary>

        [HttpGet]
        public ActionResult RemoveItem(string id)
        {

            int index = int.Parse(id);

            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            tmpList[index].IncreaseStockCount();
            Session["ListOfProducts"] = tmpList;

            Cart tmpCart = (Cart)Session["Cart"];
            Product tmpProduct = tmpCart.ProductList.ElementAt(index).Key;
            tmpCart.RemoveProduct(tmpProduct);
            Session["Cart"] = tmpCart;
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddItem(string id)
        {

            int index = int.Parse(id);
            Cart tmpCart = (Cart)Session["Cart"];
            Product tmpProduct = tmpCart.ProductList.ElementAt(index).Key;
            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];

            if (tmpList.Find(x=>x.Name == tmpProduct.Name).ReduceStockCount())
            {

                Session["ListOfProducts"] = tmpList;
                tmpCart.AddProduct(tmpProduct);
                Session["Cart"] = tmpCart;
            }

            return RedirectToAction("Index");
        }
    }
}