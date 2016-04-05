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
            Session_Start();
        }

        protected void Session_Start()
        {

            Session["Cart"] = new Cart();

            Session["ListOfProducts"] = new List<Product>()
            {

                new Product("Computer", 20000, 3),
                new Product("Bike", 2000, 1),
                new Product("Cat", 2, 3),
                new Product("LaFerarri", 42120000, 3),
                new Product("iPhone7", 14000, 90),
                new Product("MackBok", 299, 8),
                new Product("Random Laptop", 499, 12),
                new Product("Porche Carerra", 300000, 11),
                new Product("Microwave", 20, 4),
                new Product("Big Boat", 99000000, 1),
                new Product("Small Boat", 100, 30),
                new Product("Android phone", 80, 2)
            };

            Session["ListOfUsers"] = new List<User>()
            {
                new User("admin", "admin@shop.eu", "admin"),
                new User("Mr Black", "black@google.com", "1234"),
                new User("Mr Pink", "pink@google.com", "2345")
            };
        }



        }
    }
}
