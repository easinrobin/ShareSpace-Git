using System.Web.Mvc;

namespace ClientPanel.Controllers
{
    public class DashboardController : Controller
    {
        // GET: ClientDashboard
        public ActionResult Index()
        {
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
