using System.Collections.Generic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Vendor;

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


            //VendorManager.GetAllVendorsByEmailNPhone(string Email, string mobileNo)) 

            //if (vendor == null)
            //{
            //    VendorManager.UpdateVendor(vendor);
            //}
            //else
            //{
            //    VendorManager.InsertVendor(vendor);
            //}

            VendorManager manager = new VendorManager();
            if (vendor != null && vendor.VendorId > 0)
            {
                VendorManager.UpdateVendor(vendor);
            }
            else
            {
                VendorManager.InsertVendor(vendor);
            }


            return RedirectToAction("AdminVendors");
        }

        //public string GetAllVendorsByEmailNPhone(string email)
        //{
        //   VendorManager manager = new VendorManager();
        //    var emailStatus = manager.Email.Where(model => model.Email == email).FirstOrDefault();
        //    if (emailStatus != null)
        //    {
        //        return "1";
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}

        public ActionResult UpdateVendor(int vendorId)
        {
            Vendor vendor = VendorManager.GetVendorById(vendorId);
            return View("~/Views/Vendor/InsertVendor.cshtml", vendor);
        }


        public ActionResult AdminVendors()
        {
            List<Vendor> allVendors = VendorManager.GetAllVendors();
            return View("~/Views/Vendor/AdminVendors.cshtml", allVendors);
        }


        public ActionResult DeleteVendor(long vendorId)
        {
            VendorManager.DeleteVendor(vendorId);
            return RedirectToAction("AdminVendors");
        }
    }
}