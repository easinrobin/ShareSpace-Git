using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models;

namespace AdminPanel.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult InsertBooking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertBooking(Booking booking)
        {
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

            return View(booking);
        }

        public ActionResult UpdateBooking(int bookingId)
        {
            Booking booking = BookingManager.GetBookingById(bookingId);
            return View("~/Views/Booking/InsertBooking.cshtml", booking);
        }


        public ActionResult AdminBookings()
        {
            List<Booking> allBookings = BookingManager.GetAllBookings(1);
            return View("~/Views/Booking/AdminBookings.cshtml", allBookings);
        }


        public ActionResult DeleteBooking(long bookingId)
        {
            BookingManager.DeleteBooking(bookingId);
            return RedirectToAction("AdminBookings");
        }
    }
}