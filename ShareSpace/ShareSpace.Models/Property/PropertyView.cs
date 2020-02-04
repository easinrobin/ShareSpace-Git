using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShareSpace.Models.Property
{
    public class PropertyView
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
        public decimal One_hr_price { get; set; }
        public decimal Four_hr_price { get; set; }
        public decimal Weekly_price { get; set; }
        public decimal Monthly_price { get; set; }
        public decimal Three_months_price { get; set; }
        public int Rating { get; set; }
        public string VideoLink { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string HouseNo { get; set; }
        public string FlatNo { get; set; }
        public string RoadNo { get; set; }
        public int ZipCode { get; set; }

        [NotMapped]
        public int BookingId { get; set; }
        [NotMapped]
        public DateTime FromDate { get; set; }
        [NotMapped]
        public DateTime ToDate { get; set; }
        [NotMapped]
        public int TotalPerson { get; set; }
        [NotMapped]
        public string FromHour { get; set; }
        [NotMapped]
        public string ToHour { get; set; }
        [NotMapped]
        public DateTime BookingDate { get; set; }
        [NotMapped]
        public string BookingNo { get; set; }

        [NotMapped]
        public Int64 ClientId { get; set; }
        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public string LastName { get; set; }
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        public string MobileNo { get; set; }

        [NotMapped]
        [Display(Name = "I agree all statements in ")]
        [CheckBoxRequired(ErrorMessage = "Accept Terms of service")]
        public bool TermsAndConditions { get; set; }

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
                var data = HouseNo + ", "+ FlatNo + ", " + RoadNo+", " + Area + ", " + City + ", " + ZipCode + ", " + Country;
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
