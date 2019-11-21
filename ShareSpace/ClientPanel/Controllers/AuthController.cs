using System.Net;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ClientId,FirstName,LastName,Email,Country,MobileNo,BirthDate,Password")] Client client)
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
        public ActionResult Login(string email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = ClientManager.GetClientByEmail(email);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
    }
}