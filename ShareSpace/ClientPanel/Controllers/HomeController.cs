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
            List<FeatureProperty> featureProperties = PropertyManager.GetFeaturedProperties(3);
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


        //[HttpPost]
        //public ActionResult Index([Bind(Include = "ClientId,FirstName,LastName,Email,Country,MobileNo,BirthDate,Password,CreatedBy,UpdateBy,CreatedDate,UpdateDate")] Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var id = ClientManager.InsertClient(client);
        //        return RedirectToAction("Index");

        //    }
        //    return View(client);
        //}

        //[HttpPost]
        //public ActionResult Contact(long ClientId)
        //{
        //    Client client = new Client();
        //    ClientId = client.ClientId;
        //    return View();
        //}
    }
}