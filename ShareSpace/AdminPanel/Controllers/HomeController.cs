using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Client;

namespace AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = PropertyManager.GetPendingPropertyList();
            return View(model);
        }

        public ActionResult HideProperty(long propertyId)
        {
            PropertyManager.HideProperty(propertyId);
            return RedirectToAction("Index");
        }

        public ActionResult ApproveProperty(long propertyId)
        {
            PropertyManager.ApproveProperty(propertyId);
            return RedirectToAction("Index");
        }

        public ActionResult Property()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Vendors()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Client()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Booking()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Transactions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallerys()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult New_contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult InsertClient(Client client)
        {
            return View(client);
        }
    }
}