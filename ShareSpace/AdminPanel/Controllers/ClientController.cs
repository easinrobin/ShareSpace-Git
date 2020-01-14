using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Admin;
using ShareSpace.Models.Client;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult InsertClient()
        {
            _loadPassword();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertClient(AdminVWModel adminVwModel, HttpPostedFileBase image)
        {
            ClientManager manager = new ClientManager();
            
            if (adminVwModel.Clients != null && adminVwModel.Clients.ClientId > 0)
            {
                _UploadImage(adminVwModel, image);
                adminVwModel.Clients.IsInActive = false;
                adminVwModel.Clients.UpdateBy = "Admin";
                adminVwModel.Clients.UpdateDate = DateTime.Now;
                ClientManager.UpdateClient(adminVwModel.Clients);
            }
            else
            {
                if (adminVwModel.Clients != null)
                {
                    _UploadImage(adminVwModel, image);
                    adminVwModel.Clients.IsInActive = false;
                    adminVwModel.Clients.CreatedBy = "Admin";
                    adminVwModel.Clients.CreatedDate = DateTime.Now;
                    ClientManager.InsertClient(adminVwModel.Clients);
                }
            }

            return RedirectToAction("AdminClients");
        }

        public ActionResult UpdateClient(AdminVWModel adminVwModel, int clientId)
        {
            adminVwModel.Clients = ClientManager.GetClientById(clientId);
            return View("~/Views/Client/InsertClient.cshtml", adminVwModel);
        }


        public ActionResult AdminClients()
        {
            List<Client> allClients = ClientManager.GetAllClients();
            return View("~/Views/Client/AdminClients.cshtml", allClients);
        }


        public ActionResult DeleteClient(long clientId)
        {
            ClientManager.DeleteClient(clientId);
            return RedirectToAction("AdminClients");
        }

        public ActionResult HideClient(long clientId)
        {
            ClientManager.HideClient(clientId);
            return RedirectToAction("AdminClients");
        }

        private void _loadPassword()
        {
            string password = Guid.NewGuid().ToString("N").ToLower()
                .Replace("1", "").Replace("o", "").Replace("0", "")
                .Substring(0, 5);
            ViewBag.GeneratePassword = password;
        }

        private void _sendEmail(Client aClient)
        {
            try
            {
                var data = ClientManager.GetClientById(Convert.ToInt64(aClient.ClientId));

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div style=\"background:#F6F6F6;width:600px;margin:10px auto;overflow: hidden; padding-bottom:40px; box-shadow: 0 0 0 0 rgba(0, 0, 0, 0.10), 0 3px 3px 0 rgba(0, 0, 0, 0.10); font-family:Roboto, Helvetica, Arial;\">");
                sb.AppendFormat("<div style=\"padding-top:20px; text-align:center; background:#333333eb;\">");
                sb.AppendFormat("<img src=\"http://ss.byteheart.com/images/Share_space.png\" alt=\"Sharespace\">");
                sb.AppendFormat("<p style=\"font-size:30px; color:#ffff;font-weight:600;text-align:center;\">Welcome to ShareSpace</p>");
                sb.AppendFormat("<p style=\"font-size:25px; color:#ffff;font-weight:500;text-align:center;\">You are registered as a Vendor</p>");
                sb.AppendFormat("<p style=\"font-size:24px; color:#ffff;font-weight:600;text-align:center;\">Your email is: {0}</p>", aClient.Email.ToString());
                sb.AppendFormat("<p style=\"font-size:24px; color:#ffff;font-weight:600;text-align:center;\">Your password is: {0}</p>", aClient.Password);
                sb.AppendFormat("<img src=\"http://ss.byteheart.com/images/mail_middle.png\" alt='' style=\"display:block; border: 0; outline: none; text-decoration:none; -ms-interpolation-mode:bicubic; width: 600px; \" >");
                sb.AppendFormat(
                    "<p style=\"font-size:18px; color:#ffff;\">You can see details from <a style=\"color:#ffff;\" href='http://ss.byteheart.com/Auth/Login' target='_blank'> your panel </a></p>");
                sb.AppendFormat("\n<p style=\"font-size:18px; color:#ffff;\">Your username: {0} and Password: {1}</p>", aClient.Email.Trim(), aClient.Password);
                sb.AppendFormat("</div>");

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("info@thebyteheart.com", "SlimGuy@12");
                MailAddress from = new MailAddress("info@thebyteheart.com", "Sharespace", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(aClient.Email.Trim());
                MailMessage message = new MailMessage(from, to);
                MailAddress bcc = new MailAddress("mohi.byteheart@gmail.com");
                message.Bcc.Add(bcc);
                MailAddress bcc2 = new MailAddress("robineasin@gmail.com");
                message.Bcc.Add(bcc2);
                message.Body = sb.ToString();
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Subject = "Sharespace Vendor Confirmation";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                client.Send(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void _UploadImage(AdminVWModel adminVwModel, HttpPostedFileBase images)
        {
            foreach (var file in adminVwModel.Files.Take(1))
            {
                string pathUrl = "";

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
                    adminVwModel.Clients.ClientPhoto = pathUrl;
                }
            }
        }

        public JsonResult IsEmailExist(AdminVWModel av)
        {
            var emailList = ClientManager.GetAllClients();
            var email = emailList.ToList();
            if (email.All(x => x.Email.ToLower() != av.Clients.Email.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsMobileExist(AdminVWModel av)
        {
            var mobileList = ClientManager.GetAllClients();
            var mobile = mobileList.ToList();
            if (mobile.All(x => x.MobileNo.ToLower() != av.Clients.MobileNo.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}