using System.Collections.Generic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Property;

namespace ClientPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<FeatureProperty> featureProperties = PropertyManager.GetFeaturedProperties(4);
            return View("~/Views/Home/Index.cshtml",featureProperties);
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
    }
}