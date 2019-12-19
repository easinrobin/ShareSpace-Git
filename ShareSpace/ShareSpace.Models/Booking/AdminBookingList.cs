using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Booking
{
    public class AdminBookingList
    {
        [Key]
        public long BookingId { get; set; }

        [Display(Name = "Property Id")]
        public int PropertyId { get; set; }

        [Display(Name = "Property Address Id")]
        public int PropertyAddressId { get; set; }

        [Display(Name = "Client Id")]
        public int ClientId { get; set; }

        [Display(Name = "Vendor Id")]
        public int VendorId { get; set; }

        [Display(Name = "FromDate")]
        public DateTime FromDate { get; set; }

        [Display(Name = "ToDate")]
        public DateTime ToDate { get; set; }

        [Display(Name = "FromHour")]
        public string FromHour { get; set; }

        [Display(Name = "ToHour")]
        public string ToHour { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }

        [Display(Name = "Client Photo")]
        public string ClientPhoto { get; set; }

        [Display(Name = "FirstName")]
        public string VendorFirstName { get; set; }

        [Display(Name = "LastName")]
        public string VendorLastName { get; set; }

        [Display(Name = "Email")]
        public string VendorEmail { get; set; }

        [Display(Name = "MobileNo")]
        public string VendorMobileNo { get; set; }

        [Display(Name = "VendorPhoto")]
        public string VendorPhoto { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Share Type")]
        public string ShareType { get; set; }

        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Retail Price")]
        public decimal RetailPrice { get; set; }

        [Display(Name = "MaximumPerson")]
        public int MaximumPerson { get; set; }

        [Display(Name = "MaximumPerson")]
        public int BookingMaximumPerson { get; set; }

        [Display(Name = "IsHidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "House No.")]
        public string HouseNo { get; set; }

        [Display(Name = "Floor/Flat No.")]
        public string FlatNo { get; set; }

        [Display(Name = "Road No.")]
        public string RoadNo { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}
