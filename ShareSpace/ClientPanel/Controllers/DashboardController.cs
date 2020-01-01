using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Admin;
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
            client.Email = (string)Session["UserName"];
            client.ClientId = (long)Session["ClientId"];

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
            ClientViewModel cv = new ClientViewModel();
            long clientId = Session["ClientId"] != null ? Convert.ToInt64(Session["ClientId"]) : 0;
            cv.Client = ClientManager.GetClientById(clientId);
            //ClientManager.GetClientById(clientId);
            return View("~/Views/Dashboard/EditProfile.cshtml", cv);
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
        public ActionResult EditProfile(ClientViewModel cv, HttpPostedFileBase image)
        {
            _UploadImage(cv, image);
            cv.Client.CreatedBy = cv.Client.FirstName;
            cv.Client.UpdateBy = cv.Client.FirstName;
            cv.Client.IsInActive = false;
            cv.Client.CreatedDate = DateTime.Today;
            cv.Client.UpdateDate = DateTime.Today;
            Int64 clientId = Session["ClientId"] != null ? Convert.ToInt64(Session["ClientId"]) : 0;
            cv.Client.ClientId = clientId;
            bool isUpdate = ClientManager.UpdateClient(cv.Client);
            return RedirectToAction("ViewProfile");
        }

        private void _UploadImage(ClientViewModel cv, HttpPostedFileBase images)
        {
            foreach (var file in cv.Files.Take(1))
            {
                string pathUrl = "";

                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string savepath, savefile;
                        var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                        savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        savefile = Path.Combine(savepath, filename);
                        file.SaveAs(savefile);
                        pathUrl = "/img/Offices/" + filename;
                        cv.Client.ClientPhoto = pathUrl;
                    }
                }
                else
                {
                    pathUrl = cv.Client.ClientPhoto;
                }
            }
        }
    }
}
