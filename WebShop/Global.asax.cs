using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebShop.Models;
namespace WebShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            Session["UserLoggedIn"] = false;
            Session["Cart"] = new Cart();
            Session["CurrentUser"] = "";
            Session["ItemsInCart"] = 0;

            Session["ListOfProducts"] = new List<Product>()
            {
                new Product("Tomato", 20, 3, "../Content/product_pictures/tomato140.png"),
                new Product("Cucumber", 12, 1, "../Content/product_pictures/cucumber140.png"),
                new Product("Potatoes", 2, 3, "../Content/product_pictures/potatoes140.png"),
                new Product("Pasta", 41, 3, "../Content/product_pictures/pasta140.png"),
                new Product("Rice", 11, 90, "../Content/product_pictures/rice140.png"),
                new Product("Hummus", 299, 8, "../Content/product_pictures/hummus140.png"),
                new Product("Cola", 499, 12, "../Content/product_pictures/coke140.png"),
                new Product("Water", 300, 11, "../Content/product_pictures/water140.png"),
                new Product("T-bone", 2010, 4, "../Content/product_pictures/t-bone140.png"),
                new Product("Salomon", 9900, 1, "../Content/product_pictures/salomon140.png"),
                new Product("Fries", 100, 30, "../Content/product_pictures/fries140.png"),
                new Product("Watermelon", 80, 2, "../Content/product_pictures/watermelon140.png")
            };

            Session["ListOfUsers"] = new List<User>()
            {
                new User("admin", "admin@shop.eu", "admin"),
                new User("MrBlack", "black@google.com", "1234"),
                new User("MrPink", "pink@google.com", "2345"),
                new User("hejsan", "hejsan@hejsan.se", "hejsan")
            };
        }
    }
}

