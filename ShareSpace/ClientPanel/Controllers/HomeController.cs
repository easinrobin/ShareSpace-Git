using System.Web.Mvc;
using ShareSpace.BusinessLayer;

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
    }
}