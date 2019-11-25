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
        public ActionResult InsertBooking([Bind(Include = "FromDate,ToDate,MaximumPerson,FromHour,ToHour,PropertyId,ClientId")] Booking booking)
        {
            BookingManager manager = new BookingManager();
            //if (ModelState.IsValid)
            //{

            var id = manager.InsertBooking(booking);
            //return RedirectToAction("InsertBooking");
            //}
            return View(booking);
        }

        public ActionResult AdminBookings()
        {
            List<Booking> allBookings = BookingManager.GetAllBookings(1);
            return View("~/Views/Booking/AdminBookings.cshtml", allBookings);
        }




     


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult EditBooking([Bind(Include = "FromDate,ToDate,MaximumPerson,FromHour,ToHour")] Booking booking)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            BookingManager. manager = new BookingManager();
    //            var id = manager.EditBooking(booking);

                
    //        }
    //        return View("~/Views/Booking/InsertBookings.cshtml", manager);
    //    }


    }
}