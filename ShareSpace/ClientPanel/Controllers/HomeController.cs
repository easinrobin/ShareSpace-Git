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
using System.Globalization;
using Microsoft.Ajax.Utilities;
using ShareSpace.Models.NewsLetter;
using ShareSpace.Models.Testimonial;
using ShareSpace.Utility;

namespace ClientPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.featuredProperties = PropertyManager.GetFeaturedProperties(6);
            ViewBag.featuredService = ServiceManager.GetFeaturedServices(6);

            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult SearchResults(ClientViewModel cvModel)
        {
            List<PropertySearchResultNew> allPropertyList = new List<PropertySearchResultNew>();
            if (cvModel.OfficeSearch != null)
            {
                string fromDate = "";
                if (!string.IsNullOrEmpty(cvModel.OfficeSearch.FromDate))
                    fromDate = cvModel.OfficeSearch.FromDate;
                string toDate = "";
                if (!string.IsNullOrEmpty(cvModel.OfficeSearch.ToDate))
                    toDate = cvModel.OfficeSearch.ToDate;
                string fromHour = "";
                if (!string.IsNullOrEmpty(cvModel.OfficeSearch.FromHour))
                    fromHour = cvModel.OfficeSearch.FromHour;
                string toHour = "";
                if (!string.IsNullOrEmpty(cvModel.OfficeSearch.ToHour))
                    toHour = cvModel.OfficeSearch.ToHour;


                allPropertyList = PropertyManager.GetPropertiesBySearch(fromDate,
                    toDate, fromHour, toHour);

                if (allPropertyList != null)
                {
                    if (!string.IsNullOrEmpty(cvModel.OfficeSearch.ShareType))
                    {
                        if (cvModel.OfficeSearch.ShareType != "All")
                            allPropertyList = allPropertyList.Where(x => x.ShareType == cvModel.OfficeSearch.ShareType).ToList();
                    }


                    if (cvModel.OfficeSearch.NoPerson > 0)
                        allPropertyList = allPropertyList.Where(x => x.MaximumPerson == cvModel.OfficeSearch.NoPerson).ToList();

                    if ((!string.IsNullOrEmpty(cvModel.OfficeSearch.ShareType)) && (cvModel.OfficeSearch.NoPerson > 0))
                    {
                        allPropertyList = allPropertyList.Where(x => x.ShareType == cvModel.OfficeSearch.ShareType && x.MaximumPerson == cvModel.OfficeSearch.NoPerson).ToList();
                    }


                    if (allPropertyList.Count > 0)
                    {
                        _loadServices(allPropertyList, cvModel);
                    }
                    else
                    {
                        ViewBag.Message = "0";
                    }

                }
                else
                {
                    cvModel.PropertySearchResultList = new List<PropertySearchResultNew>();
                    ViewBag.Message = "0";
                }
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["search"]))
            {
                allPropertyList = PropertyManager.GetPropertiesBySearch(string.Empty,
                    string.Empty, string.Empty, string.Empty);
                if (allPropertyList != null)
                {

                    string text = Request.QueryString["search"].ToString();
                    allPropertyList = allPropertyList.Where(x => x.PropertyName.ToLower().Contains(text.ToLower()) || x.ShareType.ToLower().Contains(text.ToLower())).ToList();
                    if (allPropertyList.Count > 0)
                    {
                        _loadServices(allPropertyList, cvModel);
                    }
                    else
                    {
                        ViewBag.Message = "0";
                    }
                }
            }
            else
            {
                cvModel.PropertySearchResultList = new List<PropertySearchResultNew>();
                ViewBag.Message = "0";
            }

            return View("~/Views/Home/SearchResults.cshtml", cvModel);
        }

        private void _loadServices(List<PropertySearchResultNew> allPropertyList, ClientViewModel cvModel)
        {
            cvModel.PropertySearchResultList = allPropertyList;

            string ids = string.Join(",", allPropertyList.Select(x => x.PropertyId));
            cvModel.PropertyServiceList = PropertyManager.GetPropertyServiceByPropertyIds(ids);
        }

        public ActionResult OfficeDetails(int id)
        {
            if (ModelState.IsValid)
            {
                ClientViewModel cvModel = new ClientViewModel();
                cvModel.PropertyView = PropertyManager.GetPropertyViewById(id);

                cvModel.ClientPropertyRatings = PropertyManager.PropertyRatings(id);

                cvModel.PropertyServiceOnClient = PropertyManager.GetPropertyServicesOnClient(id);

                cvModel.GalleryList = GalleryManager.GetGalleryByPropertyId(id);

                cvModel.PropertyWorkingDays = PropertyWorkingDaysManager.GetAllPropertyWorkingDaysByPropertyId(id);

                return View("~/Views/Home/OfficeDetails.cshtml", cvModel);
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
            List<Testimonial> testimonialList = new List<Testimonial>();
            testimonialList = TestimonialManager.GetAllTestimonials();
            return View(testimonialList);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult InsertNewsLetter(string email)
        {
            NewsLetter newsLetter = new NewsLetter();
            newsLetter.Email = email;
            newsLetter.CreatedDate = DateTime.Now;
            NewsLetterManager.InsertNewsLetter(newsLetter);
            return RedirectToAction("Index");
        }

        public ActionResult BookingConfirmed(string PropertyId, string BookingId)
        {
            var model = new BookingConfirmed();
            if (Request.QueryString["PropertyId"] != null)
            {
                long propertyId = Request.QueryString["PropertyId"] != null
                    ? Convert.ToInt64(Request.QueryString["PropertyId"])
                    : 0;

                long bookingId = Request.QueryString["BookingId"] != null
                    ? Convert.ToInt64(Request.QueryString["BookingId"])
                    : 0;

                model = PropertyManager.GetPropertyViewByPropertyIdnBookingId(propertyId, bookingId);
            }
            return View("~/Views/Home/BookingConfirmed.cshtml", model);
        }

        public ActionResult Terms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OfficeDetails(BookingEmail bookingEmail, PropertyView propertyView, string address, string area, string city, string zipCode)
        {
            long bookingId = 0;
            long propertyId = propertyView.PropertyId;
            try
            {
                string password = string.Empty;
                long clientId = _checkExclient(bookingEmail.Email.Trim());
                if (clientId == 0)
                {
                    password = UtilityManager.RandomString(5);
                    clientId = _insertClient(bookingEmail, password);
                }

                string bookingNo = "SS" + UtilityManager.RandomString(5);
                bookingId = _insertBooking(bookingEmail, clientId, propertyId, bookingNo);
                //_sendEmail(bookingEmail, propertyId, bookingNo, address, area, city, zipCode, password);

            }
            catch (Exception ex)
            {
                if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.PathAndQuery);
            }

            // return RedirectToAction("BookingConfirmed");
            return RedirectToAction("BookingConfirmed", new
            {
                PropertyId = propertyId,
                BookingId = bookingId
            });
        }

        private void _sendEmail(BookingEmail bookingEmail, string propertyId, string bookingNo, string address, string area, string city, string zipCode, string password)
        {
            try
            {
                var data = PropertyManager.GetPropertyById(Convert.ToInt64(propertyId));


                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div style=\"background:#F6F6F6;width:600px;margin:10px auto;overflow: hidden; padding-bottom:40px; box-shadow: 0 0 0 0 rgba(0, 0, 0, 0.10), 0 3px 3px 0 rgba(0, 0, 0, 0.10); font-family:Roboto, Helvetica, Arial;\">");
                sb.AppendFormat("<div style=\"padding-top:20px; text-align:center; background:#333333;\">");
                sb.AppendFormat("<img src=\"http://ss.byteheart.com/images/Share_space.png\" alt=\"Sharespace\">");
                sb.AppendFormat("<p style=\"font-size:38px; color:#ffff;font-weight:800;text-align:center;\">Thank You</p>");
                sb.AppendFormat("<p style=\"font-size:24px; color:#ffff;font-weight:600;text-align:center;\">Confirmation No. #{0}</p>", bookingNo);
                sb.AppendFormat("<img src=\"http://ss.byteheart.com/images/mail_middle.png\" alt='' style=\"display:block; border: 0; outline: none; text-decoration:none; -ms-interpolation-mode:bicubic; width: 600px; \" >");
                sb.AppendFormat("</div>");
                sb.AppendFormat("<h2 style=\"padding-left:10px; line-height:26px; mso-line-height-rule:exactly; font-size:22px; font-style:normal; font-weight:normal; font-weight: 800; \">Booking Details</h2>");
                sb.AppendFormat("<div style=\"width: 600px; \">");
                sb.AppendFormat("<div style=\"width: 328px; float:left;padding-left: 10px; \">");
                sb.AppendFormat(
                    "<img  src=\"http://ss.byteheart.com/{0}\" alt='sharespace' style=\"display: block; border: 0; outline: none; text-decoration:none; -ms-interpolation-mode:bicubic; \" width=\"330\">", data.FeatureImage);
                sb.AppendFormat("</div>");
                sb.AppendFormat("<div style=\"width: 260px; float:right; \">");
                sb.AppendFormat("<div style=\"width: 245px; margin: auto; font-size:14px; \">");
                sb.AppendFormat("<p><span style=\"font-weight: 600; \">Check In:</span> {0} {1}</p>", bookingEmail.FromDate, bookingEmail.FromHour);
                sb.AppendFormat(" <p><span style=\"font-weight: 600; \">Check Out:</span> {0} {1}</p>", bookingEmail.ToDate, bookingEmail.ToHour);
                sb.AppendFormat("<p><span style=\"font-weight: 600; \">Persons:</span> {0}</p>", bookingEmail.MaximumPerson);
                sb.AppendFormat("<p><span style=\"font-weight: 600; \">Office Type:</span> {0}</p>", data.ShareType);
                sb.AppendFormat("<p><span style=\"font-weight: 600; \">Your Address:</span></p>");
                sb.AppendFormat("<p style=\"line-height:21px; \"> {0}, {1}, {2}</p>", area, city, zipCode);
                sb.AppendFormat("</div> </div></div> ");
                sb.AppendFormat("<div style=\"width: 600px; text-align:center; clear: both; padding-top: 40px; font-size:14px;\">");
                sb.AppendFormat(
                    "You can see details from <a href='http://ss.byteheart.com/Auth/Login' target='_blank'> your panel </a>");
                if (!string.IsNullOrEmpty(password))
                {
                    sb.AppendFormat("\n <br/> Your username: {0} and Password: {1}", bookingEmail.Email.Trim(), password);
                }
                sb.AppendFormat("</div></div>");


                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("info@thebyteheart.com", "SlimGuy@12");
                MailAddress from = new MailAddress("info@thebyteheart.com", "Sharespace", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(bookingEmail.Email.Trim());
                MailMessage message = new MailMessage(from, to);
                MailAddress bcc = new MailAddress("mohi.byteheart@gmail.com");
                message.Bcc.Add(bcc);
                MailAddress bcc2 = new MailAddress("robineasin@gmail.com");
                message.Bcc.Add(bcc2);
                message.Body = sb.ToString();
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Subject = "Sharespace Booking Confirmation";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                client.Send(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private long _insertBooking(BookingEmail bookingEmail, long clientId, long propertyId, string bookingNo)
        {
            long bookingId = 0;
            try
            {
                Booking data = new Booking();
                data.FromDate = Convert.ToDateTime(bookingEmail.FromDate);
                data.FromHour = bookingEmail.FromHour;
                data.MaximumPerson = bookingEmail.MaximumPerson;
                data.PropertyId = Convert.ToInt32(propertyId);
                data.ToDate = Convert.ToDateTime(bookingEmail.ToDate);
                data.ToHour = bookingEmail.ToHour;
                data.ClientId = clientId;
                data.CreatedBy = bookingEmail.Email.Trim();
                data.CreatedDate = DateTime.Now;
                data.UpdateBy = bookingEmail.Email.Trim();
                data.UpdateDate = DateTime.Now;
                data.BookingNo = bookingNo;
                bookingId = BookingManager.InsertBooking(data);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }


            return bookingId;
        }

        private long _insertClient(BookingEmail bookingEmail, string password)
        {
            long clientId = 0;
            try
            {
                DateTime? dt = null;
                Client client = new Client();
                client.BirthDate = dt;
                client.ClientPhoto = "";
                client.Country = "";
                client.CreatedBy = bookingEmail.Email.Trim();
                client.CreatedDate = DateTime.Now;
                client.Email = bookingEmail.Email.Trim();
                client.FirstName = "";
                client.LastName = "";
                client.MobileNo = bookingEmail.MobileNo;
                client.Password = password;

                clientId = ClientManager.InsertClient(client);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            return clientId;
        }

        private long _checkExclient(string email)
        {
            long clientid = 0;
            var client = ClientManager.GetClientByEmail(email);
            if (client != null)
            {
                clientid = client.ClientId;
            }

            return clientid;
        }

        [HttpPost]
        public ActionResult ClientReview(ClientViewModel clientVwModel, PropertyView propertyView)
        {
            clientVwModel.PropertyRating.ClientId = (long) Session["ClientId"];
            clientVwModel.PropertyRating.PropertyId = propertyView.PropertyId;
            clientVwModel.PropertyRating.CreatedDate = DateTime.Now;
            PropertyRatingManager.InsertPropertyRating(clientVwModel.PropertyRating);
            return RedirectToAction("OfficeDetails/"+propertyView.PropertyId);
        }

        [HttpPost]
        public ActionResult Contact(ContactForm contactForm)
        {
            Console.WriteLine("Error: Mehedi " + "Mehedi");
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
                client.Host = "smtp.office365.com";
                client.Credentials = new System.Net.NetworkCredential("info@thebyteheart.com", "SlimGuy@12");
                client.UseDefaultCredentials = true;
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
                Console.WriteLine("Error: " + e.Message);
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