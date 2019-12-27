using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;
using ShareSpace.Models.Booking;
using ShareSpace.Models.Client;
using ShareSpace.Models.Property;

namespace AdminPanel.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult InsertBooking()
        {
            _loadProperties();
            _loadClients();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertBooking(Booking booking)
        {
            //_loadProperties();
            //_loadClients();
            BookingManager manager = new BookingManager();
            //if (ModelState.IsValid)
            //{
            if (booking != null && booking.BookingId > 0)
            {
                BookingManager.UpdateBooking(booking);
            }
            else
            {
                BookingManager.InsertBooking(booking);
            }

            return RedirectToAction("AdminBookings");
        }

        public ActionResult UpdateBooking(int bookingId)
        {
            _loadProperties();
            _loadClients();
            Booking booking = BookingManager.GetBookingById(bookingId);
            return View("~/Views/Booking/InsertBooking.cshtml", booking);
        }


        public ActionResult AdminBookings()
        {
            List<AdminBookingList> allBookings = BookingManager.GetAdminBookingList();

            
            return View("~/Views/Booking/AdminBookings.cshtml", allBookings);
        }


        public ActionResult DeleteBooking(long bookingId)
        {
            BookingManager.DeleteBooking(bookingId);
            return RedirectToAction("AdminBookings");
        }

        public ActionResult BookingConfirmation()
        {
            ViewBag.Message = "Booking Confirmation";

            return View();
        }

        //public ActionResult Create()
        //{
        //    Booking booking = new Booking();
        //    _loadProperties();
        //    _loadClients();
        //    return View(booking);
        //}

        private void _loadProperties()
        {
            List<Property> dataList = PropertyManager.GetAllProperties();
            ViewBag.PropertyList = new SelectList(dataList, "PropertyId", "PropertyName");
        }

        private void _loadClients()
        {
            List<Client> dataList = ClientManager.GetAllClients();
            ViewBag.ClientList = new SelectList(dataList, "ClientId", "FirstName");
        }
    }
}