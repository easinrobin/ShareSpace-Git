using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Booking
{
    public class BookingConfirmed
    {
        public long PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string ShareType { get; set; }
        public int MaximumPerson { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string FeatureImage { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public int Rating { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string HouseNo { get; set; }
        public string FlatNo { get; set; }
        public string RoadNo { get; set; }
        public int ZipCode { get; set; }

        public int BookingId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalPerson { get; set; }
        public string FromHour { get; set; }
        public string ToHour { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingNo { get; set; }

        public Int64 ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }

        [NotMapped]
        public string FullAddressWithoutHome
        {
            get
            {
                var data = RoadNo + ", " + Area + ", " + City + ", " + ZipCode + ", " + Country;
                return data;
            }
        }
        [NotMapped]
        public string FullAddress
        {
            get
            {
                var data = HouseNo + ", " + FlatNo + ", " + RoadNo + ", " + Area + ", " + City + ", " + ZipCode + ", " + Country;
                return data;
            }
        }
        [NotMapped]
        public string FullName
        {
            get
            {
                var data = FirstName + " " + LastName;
                return data;
            }
        }
    }
}
