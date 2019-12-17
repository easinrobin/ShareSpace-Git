using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.Models.User;
using System.IO;
using ShareSpace.BusinessLayer;

namespace AdminPanel.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var data = UserManager.GetUserByUserNameNPassword(user.UserName.Trim(), user.UserPassword.Trim());
                if (data != null)
                {
                    if (user.UserRole == "Admin")
                    {
                        Session["UserID"] = data.UserID.ToString();
                        Session["UserName"] = data.UserName.ToString();
                        return View("~/Views/Home/Index.cshtml");
                    }
                    else
                    {
                        Session["VendorId"] = 2;
                        return View("~/Areas/Vendor/Views/VendorHome/Index.cshtml");
                    }
                }
                else
                {

                    ViewBag.ErrMsg = "Please enter email and password!.";

                }
            }
            else
            {

                ViewBag.ErrMsg = "Please enter email and password!.";

            }
            return View(user);

        }

    }
}