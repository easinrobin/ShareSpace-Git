using System.Collections.Generic;

namespace ShareSpace.DataLayer.Booking
{
    public interface IBookingProvider
    {
        List<Models.Booking> GetAllBookings();
    }
}