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

            Session["ListOfProducts"] = new List<Product>()
            {

                new Product("Tomato", 20, 3),
                new Product("Cucumber", 12, 1),
                new Product("Potatoes", 2, 3),
                new Product("Pasta", 41, 3),
                new Product("Rice", 11, 90),
                new Product("Hummus", 299, 8),
                new Product("Cola", 499, 12),
                new Product("Water", 300, 11),
                new Product("T-bone", 2010, 4),
                new Product("Salomon", 9900, 1),
                new Product("Fries", 100, 30),
                new Product("Watermelon", 80, 2)
            };

            Session["ListOfUsers"] = new List<User>()
            {
                new User("admin", "admin@shop.eu", "admin"),
                new User("MrBlack", "black@google.com", "1234"),
                new User("MrPink", "pink@google.com", "2345")
            };
        }
    }
}

