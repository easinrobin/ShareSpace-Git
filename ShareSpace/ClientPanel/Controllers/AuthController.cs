﻿using System;
using System.Net;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Auth;
using ShareSpace.Models.Client;
using Vereyon.Web;

namespace ClientPanel.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        private Client _checkExclient(string email)
        {
            var client = ClientManager.GetClientByEmail(email);
            if (client != null)
            {
                email = client.Email;
                FlashMessage.Danger("Email Already Exists");
            }
            return client;
        }

        private Client _checkExclientByMobile(string mobile)
        {
            var client = ClientManager.GetClientByMobile(mobile);
            if (client != null)
            {
                mobile = client.MobileNo;
                FlashMessage.Danger("Mobile No Already Exists");
            }
            return client;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ClientId,FirstName,LastName,Email,Country,MobileNo,BirthDate,Password")] Client client)
        {
            if (ModelState.IsValid)
            {
                if (_checkExclient(client.Email) == null && _checkExclientByMobile(client.MobileNo) == null)
                {
                    var id = ClientManager.InsertClient(client);
                    Session["UserName"] = client.Email;
                    Session["Password"] = client.Password;
                    client = ClientManager.GetClientByEmailAndPassword(client.Email, client.Password);
                    Session["UserName"] = client.Email;
                    Session["ClientId"] = client.ClientId;
                    Session["FirstName"] = client.FirstName;
                    Session["LastName"] = client.LastName;
                    Session["ClientPhoto"] = client.ClientPhoto;
                    Session["MobileNo"] = client.MobileNo;
                    Session["Country"] = client.Country;
                    return RedirectToAction("Index", "Dashboard", client);
                }
            }
            return View(client);
        }


        [HttpPost]
        public ActionResult Login(Client client)
        {
            if (!String.IsNullOrEmpty(client.Email) && !String.IsNullOrEmpty(client.Password))
            {
                string email = client.Email;
                string password = client.Password;
                client = ClientManager.GetClientByEmailAndPassword(email, password);

                //email = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
                if (client != null)
                {
                    Session["UserName"] = client.Email;
                    Session["ClientId"] = client.ClientId;
                    Session["FirstName"] = client.FirstName;
                    Session["LastName"] = client.LastName;
                    Session["ClientPhoto"] = client.ClientPhoto;
                    Session["MobileNo"] = client.MobileNo;
                    Session["Country"] = client.Country;
                    return RedirectToAction("Index", "Dashboard", client);
                }

                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}