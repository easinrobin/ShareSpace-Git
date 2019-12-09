using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Booking;
using ShareSpace.Models.Property;
using System.Net.Mail;
using System.Data;
using System.IO;
using System.Linq;
using Antlr.Runtime.Misc;
using ShareSpace.Models;
using ShareSpace.Models.Client;
using System;
using System.Text;

namespace ClientPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.featuredProperties = PropertyManager.GetFeaturedProperties(9);
            ViewBag.featuredService = ServiceManager.GetFeaturedServices(9);

            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult SearchResults()
        {
            ClientViewModel cvModel = new ClientViewModel();
            List<PropertySearchResultNew> allPropertyList = new List<PropertySearchResultNew>();

            allPropertyList = PropertyManager.GetPropertiesAndPropertyRating();

            cvModel.PropertySearchResultList = allPropertyList;

            string ids = string.Join(",", allPropertyList.Select(x => x.PropertyId));
            cvModel.PropertyServiceList = PropertyManager.GetPropertyServiceByPropertyIds(ids);

            return View("~/Views/Home/SearchResults.cshtml", cvModel);
        }

        public ActionResult OfficeDetails(int id)
        {
            if (ModelState.IsValid)
            {
                PropertyDetails propertyDetails = new PropertyDetails();
                propertyDetails = PropertyManager.GetPropertyDetailsById(id);
                propertyDetails.ClientPropertyRatings = PropertyManager.PropertyRatings(id);
                propertyDetails.PropertyServiceOnClient = PropertyManager.GetPropertyServicesOnClient(id);

                return View("~/Views/Home/OfficeDetails.cshtml", propertyDetails);
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public ActionResult Office(string type)
        {
            if (type == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientViewModel cvModel = new ClientViewModel();
            List<PropertySearchResultNew> propertyList = new List<PropertySearchResultNew>();
            propertyList = PropertyManager.GetShareType(type);
            cvModel.PropertySearchResultList = propertyList;
            string ids = string.Join(",", propertyList.Select(x => x.PropertyId));
            cvModel.PropertyServiceList = PropertyManager.GetPropertyServiceByPropertyIds(ids);
            return View("~/Views/Home/Office.cshtml", cvModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult BookingConfirmed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OfficeDetails(BookingEmail bookingEmail, string propertyName, string address, string area, string city, string zipCode)
        {
            try
            {


                string checkInDate = bookingEmail.FromDate;
                string checkOutDate = bookingEmail.ToDate;
                string checkInTime = bookingEmail.FromHour;
                string checkOutTime = bookingEmail.ToHour;
                string email = bookingEmail.Email;
                int person = bookingEmail.MaximumPerson;

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Hello Dear Customer,\n");
                sb.AppendFormat("Your booking request from: {0} at {1} to {2} at {3} ", checkInDate, checkInTime, checkOutDate, checkOutTime);
                sb.AppendFormat(" Location: {0} {1}, {2}, {3}, {4} ", propertyName, address, area, city, zipCode);
                sb.AppendFormat("Has been confirmed\n  You are allowed to bring maximum {0} ", person);
                sb.AppendFormat("with you.");

                //SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                //client.EnableSsl = true;
                //client.Credentials = new System.Net.NetworkCredential("info@thebyteheart.com", "SlimGuy@12");
                //MailAddress from = new MailAddress("info@thebyteheart.com", "Sharespace", System.Text.Encoding.UTF8);
                //MailAddress to = new MailAddress(email);
                //MailMessage message = new MailMessage(from, to);
                //MailAddress bcc = new MailAddress("sharespace.bh@gmail.com");
                //message.Bcc.Add(bcc);
                //MailAddress bcc2 = new MailAddress("robineasin@gmail.com");
                //message.Bcc.Add(bcc2);
                //message.Body = sb.ToString();
                //message.BodyEncoding = System.Text.Encoding.UTF8;
                //message.Subject = "Sharespace Booking Confirmation";
                //message.SubjectEncoding = System.Text.Encoding.UTF8;
                //client.Send(message);

            }
            catch (Exception ex)
            {
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }

            return RedirectToAction("BookingConfirmed");
        }

        [HttpPost]
        public ActionResult Contact(ContactForm contactForm)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Hi Team,\n");
                sb.AppendFormat("This is from sharespace Contact us enquiry:\n");
                sb.AppendFormat(" Name: {0}", contactForm.Name);
                sb.AppendFormat("\n Email: {0}", contactForm.Email);
                sb.AppendFormat("\n Mobile No: {0}", contactForm.MobileNo);
                sb.AppendFormat("\n Message: {0}", contactForm.Message);

                // SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("info@thebyteheart.com", "SlimGuy@12");
                MailAddress from = new MailAddress("info@thebyteheart.com", "Sharespace", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress("sharespace.bh@gmail.com");
                MailMessage message = new MailMessage(from, to);
                MailAddress bcc = new MailAddress("robineasin@gmail.com");
                message.Bcc.Add(bcc);
                message.Body = sb.ToString();
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "Sharespace Contact us Enquiry";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                client.Send(message);
            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }



            return View();
        }

        public void SendEmail(string email, string password, string subject, string body,
            MailAddress from, MailAddress to,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null)
        {

            var message = new MailMessage();
            message.From = from;
            message.To.Add(to);
            if (null != bcc)
            {
                foreach (var address in bcc.Where(bccValue => !String.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(address.Trim());
                }
            }
            if (null != cc)
            {
                foreach (var address in cc.Where(ccValue => !String.IsNullOrWhiteSpace(ccValue)))
                {
                    message.CC.Add(address.Trim());
                }
            }
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = false;
                //smtpClient.Host = "smtpout.secureserver.net";
                smtpClient.Host = "relay-hosting.secureserver.net";
                smtpClient.Port = 25;
                smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(email, password);
                smtpClient.Send(message);
            }
        }
    }
}