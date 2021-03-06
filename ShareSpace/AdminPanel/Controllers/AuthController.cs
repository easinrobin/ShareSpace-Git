﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.Models.User;
using System.IO;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Role user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserRole == "Admin")
                {
                    var data = UserManager.GetUserByUserNameNPassword(user.UserName.Trim(), user.UserPassword.Trim());
                    if (data != null)
                    {

                        Session["UserID"] = data.UserID.ToString();
                        Session["UserName"] = data.UserName.ToString();
                        Session["Name"] = "Site Admin";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrMsg = "Please enter email and password!.";
                    }
                }
                else if (user.UserRole == "Vendor")
                {
                    var data = VendorManager.GetVendorByEmailPassword(user.UserName.Trim(), user.UserPassword.Trim());
                    if (data != null)
                    {
                        Session["VendorId"] = data.VendorId;
                        Session["UserName"] = data.Email.ToString();
                        Session["Name"] = data.FirstName;
                        Session["VendorPhoto"] = data.VendorPhoto;
                        return View("~/Areas/VendorPanel/Views/VendorHome/Index.cshtml");
                    }
                    else
                    {
                        ViewBag.ErrMsg = "Please enter email and password!.";
                    }
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