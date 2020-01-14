using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.Models.Client;

namespace ShareSpace.DataLayer.Booking
{
    public interface IBookingProvider
    {
        List<Models.Booking.Booking> GetAllBookings();
        long InsertBooking(Models.Booking.Booking booking);
        bool UpdateBooking(Models.Booking.Booking booking);
        Models.Booking.Booking GetBookingById(long bookingId);
        bool DeleteBooking(long bookingId);
        List<ClientsBookingHistory> GetClientBookingHistory(long clientId);
    }
}
