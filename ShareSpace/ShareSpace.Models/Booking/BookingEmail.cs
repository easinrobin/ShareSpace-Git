using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Booking
{
    public class BookingEmail
    { 
   
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FromHour { get; set; }
        public string ToHour { get; set; }
        public int MaximumPerson { get; set; }
        public string Email { get; set; }
       
        public string MobileNo { get; set; }
    }
}
