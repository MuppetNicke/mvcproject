using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register()
        {

            List<User> tmpList = (List<User>)Session["ListOfUsers"];
            string tmpMail = Request["mailInput"];
            bool mailFound = false;

            foreach(User x in tmpList)
            {
                if(x.Email == tmpMail)
                {
                    mailFound = true;
                    break;
                }
            }

            if (mailFound)
            {
                return Redirect("/Default/Index");
            }

            string tmpName = Request["nameInput"];
            string tmpPassword = Request["passwordInput"];

            tmpList.Add(new User(tmpName, tmpMail, tmpPassword));
            tmpList = (List<User>)Session["ListOfUsers"];

            return Redirect("/Default/Index");
        }

        
        [HttpPost]
        public ActionResult Login()
        {
            string user = Request["emailInput"];
            string password = Request["passwordInput"];
            
            foreach (User x in (List<User>)Session["ListOfUsers"])
            {
                if (x.Email == user)
                {
                    if(x.Password == password)
                    {
                        Session["UserLoggedIn"] = true;
                        Session["CurrentUser"] = user;
                        Session["Cart"] = new Cart();
                    }
                }

                else { }
            }

            return Redirect("/Default/Index");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["UserLoggedIn"] = false;
            Session["CurrentUser"] = "";
            Session["Cart"] = new Cart();

            return Redirect("/Default/Index");
        }
    }
}