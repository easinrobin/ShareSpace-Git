using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

namespace AdminPanel.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult InsertVendor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertVendor([Bind(Include = "VendorId,FirstName,LastName,Email,Country,MobileNo,Password")] Vendor vendor)
        {
            VendorManager manager = new VendorManager();
            //if (ModelState.IsValid)
            //{

                var id = manager.InsertVendor(vendor);
                //return RedirectToAction("InsertVendor");
            //}
            return View(vendor);
        }
        

    }
}