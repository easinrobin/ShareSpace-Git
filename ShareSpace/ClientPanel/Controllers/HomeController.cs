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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult OfficeDetails()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Office(string type)
        {
            if (type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Property> propertyList = new List<Property>();
            propertyList = PropertyManager.GetShareType(type);
            return View("~/Views/Home/Office.cshtml",propertyList);
        }
    }
}