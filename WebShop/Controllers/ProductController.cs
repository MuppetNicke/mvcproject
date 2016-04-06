﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        public ActionResult AddProduct()
        {

            string tmpName = Request["productName"];
            int tmpPrice, tmpStock;

            if (int.TryParse(Request["productPrice"], out tmpPrice) && int.TryParse(Request["productStock"], out tmpStock)
                && tmpName != null)
            {
                List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
                tmpList.Add(new Product(tmpName, tmpPrice, tmpStock));
            }

            return Redirect("/Default/Index");
        }
        [HttpPost]
        public ActionResult RemoveProduct()
        {

            var id = Request["removeproduct"];
            int productId = int.Parse(id);
            int choosenProduct = 0;

            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            foreach (var product in tmpList)
            {
                if (choosenProduct == productId)
                {
                    tmpList.Remove(product);
                    Session["ListOfProducts"] = tmpList;
                    return Redirect("/Default/Index");
                }
                choosenProduct++;
            }
            return Redirect("/Default/Index");
        }

        [HttpGet]
        public ActionResult GetProduct(int id)
        {
            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            Product tmpProduct = tmpList[id];

            return View(tmpProduct);
        }

        [HttpPost]
        public ActionResult SearchForProduct()
        {
            int id = 0;
            string prodSearch = Request["searchField"];
            int productId = 0;

            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            foreach (var product in tmpList)
            {

                if (prodSearch == product.Name)
                {
                    productId = id;

                    return RedirectToAction("GetProduct/" + id);
                }

                id++;
            }

            return Redirect("/Default/Index");
        }
    }
}