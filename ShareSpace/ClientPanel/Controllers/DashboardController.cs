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
        public ActionResult Index()
        {
            Client client = new Client();
            //client.Email = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
            Session["UserName"] = client.Email;
            Session["ClientId"] = client.ClientId;

            if (client.Email != null)
            {
                client = ClientManager.GetClientByEmail(client.Email);
                if (client == null)
                {
                    return View("~/Views/Auth/Login.cshtml");
                }

                return View();
            }
            return View("~/Views/Auth/Login.cshtml");
        }

        public ActionResult ViewProfile()
        {
            return View("Index");
        }

        public ActionResult EditProfile()
        {
            return View();
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

        
    }
}
