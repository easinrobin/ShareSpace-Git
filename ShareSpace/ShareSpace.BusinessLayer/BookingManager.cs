using System.Collections;
using System.Collections.Generic;
using ShareSpace.DataLayerSql.Booking;
using ShareSpace.Models;

namespace ShareSpace.BusinessLayer
{
    public class BookingManager
    {
        #region Get
        public static List<Booking> GetAllBookings(int i)
        {
            SqlBookingProvider sqlBookingProvider = new SqlBookingProvider();
            var allBookings = sqlBookingProvider.GetAllBookings();
            return allBookings;
        }

        public static Booking GetBookingById(long bookingId)
        {
            SqlBookingProvider sqlBookingProvider = new SqlBookingProvider();
            return sqlBookingProvider.GetBookingById(bookingId);
        }


        #endregion
        #region Set
        public static long InsertBooking(Booking booking)
        {
            SqlBookingProvider sqlBookingProvider = new SqlBookingProvider();
            var id = sqlBookingProvider.InsertBooking(booking);
            return id;
        }

        public static bool UpdateBooking(Booking booking)
        {
            SqlBookingProvider sqlBookingProvider = new SqlBookingProvider();
            var isUpdate = sqlBookingProvider.UpdateBooking(booking);
            return isUpdate;
        }

        public static bool DeleteBooking(long bookingId)
        {
            SqlBookingProvider sqlBookingProvider = new SqlBookingProvider();
            var isDelete = sqlBookingProvider.DeleteBooking(bookingId);
            return isDelete;
        }
        #endregion


    }
}