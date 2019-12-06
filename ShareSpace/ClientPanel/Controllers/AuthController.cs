using System;
using System.Net;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Auth;
using ShareSpace.Models.Client;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ClientId,FirstName,LastName,Email,Country,MobileNo,BirthDate,Password")] Client client)
        {
            if (ModelState.IsValid)
            {
                var id = ClientManager.InsertClient(client);
                return RedirectToAction("Login");
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

                Session["UserName"] = client.Email;
                Session["ClientId"] = client.ClientId;
                Session["FirstName"] = client.FirstName;
                Session["LastName"] = client.LastName;
                Session["ClientPhoto"] = client.ClientPhoto;
                Session["MobileNo"] = client.MobileNo;
                Session["Country"] = client.Country;
                return View("~/Views/Dashboard/Index.cshtml", client);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}