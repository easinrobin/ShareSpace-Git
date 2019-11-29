using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.DataLayerSql.Vendor;
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
        public ActionResult InsertVendor(Vendor vendor)
        {
            VendorManager manager = new VendorManager();
            //if (ModelState.IsValid)
            //{
            if (vendor != null && vendor.VendorId > 0)
            {
                VendorManager.UpdateVendor(vendor);
            }
            else
            {
                VendorManager.InsertVendor(vendor);
                
            }

            //return RedirectToAction("InsertVendor");
            //}
            return RedirectToAction("AdminVendors");
        }

        public ActionResult UpdateVendor(int vendorId)
        {
            Vendor vendor = VendorManager.GetVendorById(vendorId);
            return View("~/Views/Vendor/InsertVendor.cshtml", vendor);
        }


        public ActionResult AdminVendors()
        {
             List<Vendor> allVendors = VendorManager.GetAllVendors(1);
            return View("~/Views/Vendor/AdminVendors.cshtml", allVendors);
        }


        public ActionResult DeleteVendor(long vendorId)
        {
            VendorManager.DeleteVendor(vendorId);
            return RedirectToAction("AdminVendors");
        }
        

    }
}