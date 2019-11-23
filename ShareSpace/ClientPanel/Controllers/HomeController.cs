using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Property;
using ShareSpace.Models.Service;

namespace ClientPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //List<FeatureProperty> featureProperties = PropertyManager.GetFeaturedProperties(4);
            //List<FeaturedServices> featuredServices = ServiceManager.GetFeaturedServices(5);

            //ViewBag["featuredService"] = ServiceManager.GetFeaturedServices(5);
            //ViewBag["featuredProperties"] = PropertyManager.GetFeaturedProperties(4);

            ViewBag.featuredProperties = PropertyManager.GetFeaturedProperties(4);
            ViewBag.featuredService = ServiceManager.GetFeaturedServices(6);


            //var tuple = new Tuple<FeatureProperty, Services>(new FeatureProperty(), new Services());
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
    }
}