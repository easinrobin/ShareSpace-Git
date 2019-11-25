using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

namespace AdminPanel.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Vendor
        public ActionResult InsertProperty()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertProperty([Bind(Include = "PropertyId,PropertyName,MaximumPerson,Price,PropertyAddressId,PropertyServiceId,VendorId")] Property property)
        {
            PropertyManager manager = new PropertyManager();
            //if (ModelState.IsValid)
            //{

            var id = manager.InsertProperty(property);
            //return RedirectToAction("InsertVendor");
            //}
            return View(property);
        }


        public ActionResult AdminPropertys()
        {
            List<Property> allPropertys = PropertyManager.GetAllPropertys(1);
            return View("~/Views/Property/AdminPropertys.cshtml", allPropertys);
        }
    }
}