using System;
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
            string picLink = "../Content/steak.png";

            if (int.TryParse(Request["productPrice"], out tmpPrice) && int.TryParse(Request["productStock"], out tmpStock)
                && tmpName != null)
            {
                List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
                tmpList.Add(new Product(tmpName, tmpPrice, tmpStock, picLink));
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

            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            List<Product> newList = new List<Product>();

            foreach (var product in tmpList)
            {

                if (product.Name.ToLower().Contains(prodSearch.ToLower()))
                {
                    newList.Add(tmpList[id]);
                }

                id++;
            }

            return View(newList);
        }

        public ActionResult ChangeProduct()
        {

            List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
            List<Product> newList = new List<Product>();
            

            int productPrice = 0;
            int productInStock = 0;

            string productName = Request["newProductName"];
            string productPriceStr = Request["newProductPrice"];
            string productInStockStr = Request["newProductStock"];

            int id = 0;


            foreach (var item in tmpList)
            {

                if (productName.ToLower() == item.Name.ToLower())
                {
                    if (!string.IsNullOrWhiteSpace(productPriceStr))
                    {
                        if(int.TryParse(productPriceStr,out productPrice))
                        {
                            item.ChangePrice(productPrice);

                            
                        }
                        else
                        {
                            Console.WriteLine("Product Price kunde inte konverteras till en int!");

                        }

                    }
                    else
                    {
                        Console.WriteLine("Product Price är tomt, ingen ändring");

                    }


                    if (!string.IsNullOrWhiteSpace(productInStockStr))
                    {
                        if (int.TryParse(productInStockStr, out productInStock))
                        {
                            item.ChangeStock(productInStock);


                        }
                        else
                        {
                            Console.WriteLine("Product In Stock kunde inte konverteras till en int!");

                        }

                    }
                    else
                    {
                        Console.WriteLine("Product In Stock är tomt, ingen ändring");

                    }

                    return RedirectToAction("../Product/GetProduct", new { id = id });
                }

                id++;
            }
            id--;


            return RedirectToAction("../Product/GetProduct", new { id = id });
        }


    }
}