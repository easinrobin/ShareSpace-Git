using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Property;

namespace ClientPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.featuredProperties = PropertyManager.GetFeaturedProperties(6);
            ViewBag.featuredService = ServiceManager.GetFeaturedServices(6);

            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult SearchResults()
        {
            if (ModelState.IsValid)
            {
                List<PropertySearchResult> allPropertyList = new List<PropertySearchResult>();
                allPropertyList = PropertyManager.GetAllProperties();
                return View("~/Views/Home/SearchResults.cshtml", allPropertyList);
            }

            return View();
        }

        public ActionResult OfficeDetails(int id)
        {
            if (ModelState.IsValid)
            {
                PropertyDetails propertyDetails = new PropertyDetails();
                propertyDetails = PropertyManager.GetPropertyDetailsById(id);
                propertyDetails.ClientPropertyRatings = PropertyManager.PropertyRatings(id);
                return View("~/Views/Home/OfficeDetails.cshtml", propertyDetails);
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public ActionResult Office(string type)
        {
            if (type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<PropertySearchResult> propertyList = new List<PropertySearchResult>();
            propertyList = PropertyManager.GetShareType(type);
            return View("~/Views/Home/Office.cshtml",propertyList);
        }
    }
}