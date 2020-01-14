using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Admin;
using ShareSpace.Models.Vendor;

namespace AdminPanel.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        public ActionResult InsertVendor()
        {
            _loadPassword();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertVendor(AdminVWModel adminVwModel, HttpPostedFileBase image)
        {
            VendorManager manager = new VendorManager();
            if (adminVwModel.Vendors != null && adminVwModel.Vendors.VendorId > 0)
            {
                _UploadImage(adminVwModel, image);
                adminVwModel.Vendors.IsInActive = false;
                adminVwModel.Vendors.UpdateBy = "Admin";
                adminVwModel.Vendors.UpdateDate = DateTime.Now.Date;
                VendorManager.UpdateVendor(adminVwModel.Vendors);
            }
            else
            {
                _UploadImage(adminVwModel, image);
                if (adminVwModel.Vendors != null)
                {
                    _UploadImage(adminVwModel, image);
                    adminVwModel.Vendors.IsInActive = false;
                    adminVwModel.Vendors.CreatedBy = "Admin";
                    adminVwModel.Vendors.CreatedDate = DateTime.Now.Date;
                    VendorManager.InsertVendor(adminVwModel.Vendors);
                    //_sendEmail(adminVwModel.Vendors);
                }
            }
            return RedirectToAction("AdminVendors");
        }

        public ActionResult UpdateVendor(AdminVWModel adminVwModel, int vendorId)
        {
            adminVwModel.Vendors = VendorManager.GetVendorById(vendorId);
            return View("~/Views/Vendor/InsertVendor.cshtml", adminVwModel);
        }


        public ActionResult AdminVendors()
        {
            List<Vendor> allVendors = VendorManager.GetAllVendors();
            return View("~/Views/Vendor/AdminVendors.cshtml",allVendors);
        }


        public ActionResult DeleteVendor(long vendorId)
        {
            VendorManager.DeleteVendor(vendorId);
            return RedirectToAction("AdminVendors");
        }

        public ActionResult HideVendor(long vendorId)
        {
            VendorManager.HideVendor(vendorId);
            PropertyManager.HidePropertyByVendorId(vendorId);
            return RedirectToAction("AdminVendors");
        }

        private void _loadPassword()
        {
            string password = Guid.NewGuid().ToString("N").ToLower()
                .Replace("1", "").Replace("o", "").Replace("0", "")
                .Substring(0, 5);
            ViewBag.GeneratePassword = password;
        }

        private void _sendEmail(Vendor vendor)
        {
            try
            {
                var data = VendorManager.GetVendorById(Convert.ToInt64(vendor.VendorId));
                
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div style=\"background:#F6F6F6;width:600px;margin:10px auto;overflow: hidden; padding-bottom:40px; box-shadow: 0 0 0 0 rgba(0, 0, 0, 0.10), 0 3px 3px 0 rgba(0, 0, 0, 0.10); font-family:Roboto, Helvetica, Arial;\">");
                sb.AppendFormat("<div style=\"padding-top:20px; text-align:center; background:#333333eb;\">");
                sb.AppendFormat("<img src=\"http://ss.byteheart.com/images/Share_space.png\" alt=\"Sharespace\">");
                sb.AppendFormat("<p style=\"font-size:30px; color:#ffff;font-weight:600;text-align:center;\">Welcome to ShareSpace</p>");
                sb.AppendFormat("<p style=\"font-size:25px; color:#ffff;font-weight:500;text-align:center;\">You are registered as a Vendor</p>");
                sb.AppendFormat("<p style=\"font-size:24px; color:#ffff;font-weight:600;text-align:center;\">Your email is: {0}</p>", vendor.Email.ToString());
                sb.AppendFormat("<p style=\"font-size:24px; color:#ffff;font-weight:600;text-align:center;\">Your password is: {0}</p>", vendor.Password);
                sb.AppendFormat("<img src=\"http://ss.byteheart.com/images/mail_middle.png\" alt='' style=\"display:block; border: 0; outline: none; text-decoration:none; -ms-interpolation-mode:bicubic; width: 600px; \" >");
                sb.AppendFormat(
                    "<p style=\"font-size:18px; color:#ffff;\">You can see details from <a style=\"color:#ffff;\" href='http://ss.byteheart.com/Auth/Login' target='_blank'> your panel </a></p>");
                sb.AppendFormat("\n<p style=\"font-size:18px; color:#ffff;\">Your username: {0} and Password: {1}</p>", vendor.Email.Trim(), vendor.Password);
                sb.AppendFormat("</div>");
                

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("info@thebyteheart.com", "SlimGuy@12");
                MailAddress from = new MailAddress("info@thebyteheart.com", "Sharespace", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(vendor.Email.Trim());
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
                    adminVwModel.Vendors.VendorPhoto = pathUrl;
                }
            }
        }

        public JsonResult IsEmailExist(AdminVWModel av)
        {
            var emailList = VendorManager.GetAllVendors();
            var email = emailList.ToList();
            if (email.All(x => x.Email.ToLower() != av.Vendors.Email.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsMobileExist(AdminVWModel av)
        {
            var mobileList = VendorManager.GetAllVendors();
            var mobile = mobileList.ToList();
            if (mobile.All(x => x.MobileNo.ToLower() != av.Vendors.MobileNo.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}