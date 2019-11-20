using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

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

        public ActionResult History()
        {
            return View();
        }
    }
}
