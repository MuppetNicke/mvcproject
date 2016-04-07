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
            string checkChars = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{ 2,9})$";

            foreach (User x in tmpList)
            {
                if (x.Email == tmpMail)
                {
                    return Redirect("/User/Emailexists");
                }
            }

            string tmpName = Request["nameInput"];
            string tmpPassword = Request["passwordInput"];

            if (tmpName.Length >= 6 && tmpMail != null && Regex.IsMatch(tmpMail, checkChars) && tmpPassword.Length >= 6)
            {
                tmpList.Add(new User(tmpName, tmpMail, tmpPassword));
                tmpList = (List<User>)Session["ListOfUsers"];
                return Redirect("/User/Regsuccess");
            }

            return Redirect("/User/Regerror");
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
                    if (x.Password == password)
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
            Session["ItemsInCart"] = 0;

            return Redirect("/Default/Index");
        }
        [HttpGet]
        public ActionResult Emailexists()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Regsuccess()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Regerror()
        {
            return View();
        }
    }
}