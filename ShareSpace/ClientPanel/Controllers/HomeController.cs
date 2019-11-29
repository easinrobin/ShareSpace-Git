using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.Booking;
using ShareSpace.Models.Property;
using System.Net.Mail;
using Antlr.Runtime.Misc;
using ShareSpace.Models;

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
            if (ModelState.IsValid)
            {
                List<PropertySearchResult> allPropertyList = new List<PropertySearchResult>();
                allPropertyList = PropertyManager.GetAllProperties();
                return View("~/Views/Home/SearchResults.cshtml", allPropertyList);
            }

            return View();
        }

        public ActionResult OfficeDetails(int id)
        {
            if (ModelState.IsValid)
            {
                PropertyDetails propertyDetails = new PropertyDetails();
                propertyDetails = PropertyManager.GetPropertyDetailsById(id);
                propertyDetails.ClientPropertyRatings = PropertyManager.PropertyRatings(id);
                
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

            List<PropertySearchResult> propertyList = new List<PropertySearchResult>();
            propertyList = PropertyManager.GetShareType(type);
            return View("~/Views/Home/Office.cshtml",propertyList);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OfficeDetails(BookingEmail bookingEmail)
        {
            string checkInDate = bookingEmail.FromDate;
            string checkOutDate = bookingEmail.ToDate;
            string checkInTime = bookingEmail.FromHour;
            string checkOutTime = bookingEmail.ToHour;
            string email = bookingEmail.Email;
            int person = bookingEmail.MaximumPerson;
            
            var fromAddress = new MailAddress("sharespace.bh@gmail.com", "ShareSpace");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "ss@bh#1230";
            const string subject = "Booking Confirmation";
            string body = "Hello Dear Customer,\n" +
                          "Your booking request from " + checkInDate + " at " + checkInTime + " to " + checkOutDate +
                          " at " + checkOutTime + " Has been confirmed\n" +
                          "You are allowed to bring maximum " + person + " with you";
                               

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Contact(ContactForm contactForm)
        {
            string name = contactForm.Name;
            string email = contactForm.Email;
            string mobile = contactForm.MobileNo;
            string feedbackMessage = contactForm.Message;

            var fromAddress = new MailAddress(email, name);
            var toAddress = new MailAddress("sharespace.bh@gmail.com", "ShareSpace");
            //const string fromPassword = "ss@bh#1230";
            const string subject = "Feedback";
            string body = feedbackMessage + mobile;


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            return View();
        }
    }
}