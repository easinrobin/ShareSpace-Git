using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ClientId,FirstName,LastName,Email,Country,MobileNo,Password")] Client client)
        {
            ClientManager manager = new ClientManager();
            if (ModelState.IsValid)
            {

                var id = manager.InsertClient(client);
                return RedirectToAction("Login");
            }
            return View(client);
        }


        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                return View("Login");
            }
            catch
            {
                return View();
            }
        }


    }
}