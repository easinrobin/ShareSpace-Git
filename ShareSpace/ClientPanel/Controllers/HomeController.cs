using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

namespace ClientPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "ClientId,FirstName,LastName,Email,Country,MobileNo,BirthDate,Password,CreatedBy,UpdateBy,CreatedDate,UpdateDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                var id = ClientManager.InsertClient(client);
                return RedirectToAction("Index");

            }
            return View(client);
        }

        [HttpPost]
        public ActionResult Contact(long ClientId)
        {
            Client client = new Client();
            ClientId = client.ClientId;
            return View();
        }
    }
}