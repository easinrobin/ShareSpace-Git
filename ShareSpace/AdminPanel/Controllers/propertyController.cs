using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using System.IO;

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
        public ActionResult InsertProperty( Property property)
        {
            if (property != null && property.PropertyId > 0)
            {
                PropertyManager.UpdateProperty(property);
            }
            else
            {
                PropertyManager.InsertProperty(property);
            }

           

                return RedirectToAction("AdminPropertys");
        }

        public ActionResult UpdateProperty(int propertyId)
        {
            Property property= PropertyManager.GetPropertyById(propertyId);
            return View("~/Views/Property/InsertProperty.cshtml", property);
        }

        public ActionResult AdminPropertys()
        {
            List<Property> allPropertys = PropertyManager.GetAllPropertys(1);
            return View("~/Views/Property/AdminPropertys.cshtml", allPropertys);
        }

        public ActionResult DeleteProperty(long propertyId)
        {
            PropertyManager.DeleteProperty(propertyId);
            return RedirectToAction("Adminpropertys");
        }




        
    }
}