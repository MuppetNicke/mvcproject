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

            if(int.TryParse(Request["productPrice"], out tmpPrice) && int.TryParse(Request["productStock"], out tmpStock)
                && tmpName != null)
            {
                List<Product> tmpList = (List<Product>)Session["ListOfProducts"];
                tmpList.Add(new Product ( tmpName, tmpPrice, tmpStock ));
            }

            return Redirect("/Default/Index");
        }
    }
}