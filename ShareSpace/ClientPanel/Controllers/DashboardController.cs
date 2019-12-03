using System.Collections.Generic;
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
            //string email = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
            //Client client = null;
            //if (!string.IsNullOrEmpty(email))
            //{
            //    client = ClientManager.GetClientByEmail(email);
            //}
            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }

        public ActionResult History(int clientId = 13)
        {
            if (ModelState.IsValid)
            {
                List<ClientsBookingHistory> bookingHistoryList = new List<ClientsBookingHistory>();
                bookingHistoryList = BookingManager.ClientsBookingHistory(clientId);
                return View("~/Views/Dashboard/History.cshtml", bookingHistoryList);
            }
            return View("~/Views/Error");
        }
    }
}
