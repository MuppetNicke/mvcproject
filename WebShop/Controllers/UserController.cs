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

            string tmpName = Request["nameInput"];
            string tmpMail = Request["mailInput"];
            string tmpPassword = Request["passwordInput"];

            string checkChars = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{ 2,9})$";

            if (tmpName.Length >= 6 && tmpMail != null && Regex.IsMatch(tmpMail, checkChars) && tmpPassword.Length >= 6)
            {
                tmpList.Add(new User(tmpName, tmpMail, tmpPassword));
                tmpList = (List<User>)Session["ListOfUsers"];
            }

            else
            {
                return Redirect("/User/Index");
            }

            return Redirect("/Default/Index");

        }
    }
}