using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Client;

namespace ClientPanel.Controllers
{
    public class DashboardController : Controller
    {
        // GET: ClientDashboard
        public ActionResult Index(Client client)
        {
            ViewBag.featuredProperties = PropertyManager.GetFeaturedProperties(6);
            
            //client.Email = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
            Session["UserName"] = client.Email;
            Session["ClientId"] = client.ClientId;

            if (client.Email != null)
            {
                client = ClientManager.GetClientByEmail(client.Email);
                return View(client);
            }
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult ViewProfile()
        {
            long clientId = Session["ClientId"] != null ? Convert.ToInt64(Session["ClientId"]) : 0;
            Client client = ClientManager.GetClientById(clientId);
            return RedirectToAction("Index", client);
        }

        //public ActionResult EditProfile()
        //{
        //    return View();
        //}

        public ActionResult EditProfile()
        {
            long clientId = Session["ClientId"] != null ? Convert.ToInt64(Session["ClientId"]) : 0;
            Client client = ClientManager.GetClientById(clientId);
            //ClientManager.GetClientById(clientId);
            return View("~/Views/Dashboard/EditProfile.cshtml", client);
        }

        public ActionResult History()
        {
            if (ModelState.IsValid)
            {

                Int64 clientId = Session["ClientId"] != null ? Convert.ToInt64(Session["ClientId"]) : 0;
                List<ClientsBookingHistory> bookingHistoryList = new List<ClientsBookingHistory>();

                bookingHistoryList = BookingManager.ClientsBookingHistory(clientId);
                return View("~/Views/Dashboard/History.cshtml", bookingHistoryList.ToList());
            }
            return View("~/Views/Error");
        }

        [HttpPost]
        public ActionResult EditProfile(Client client)
        {
            client.ClientPhoto = "none";
            client.CreatedBy = client.FirstName;
            client.UpdateBy = client.FirstName;
            client.CreatedDate = DateTime.Today;
            client.UpdateDate = DateTime.Today;
            Int64 clientId = Session["ClientId"] != null ? Convert.ToInt64(Session["ClientId"]) : 0;
            client.ClientId = clientId;
            bool isUpdate = ClientManager.UpdateClient(client);
            return View();
        }
    }
}
