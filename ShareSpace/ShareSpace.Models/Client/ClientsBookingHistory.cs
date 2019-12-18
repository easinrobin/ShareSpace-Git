using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Client
{
    public class ClientsBookingHistory
    {
        [Key]
        [Display(Name="Client Id")]
        public int ClientId { get; set; } 

        [Display(Name = "Booking Id")]
        public int BookingId { get; set; }

        [Display(Name = "Property Id")]
        public int PropertyId { get; set; }

        [Display(Name = "Property Address Id")]
        public int PropertyAddressId { get; set; }

        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "From Hour")]
        public string FromHour { get; set; }

        [Display(Name = "To Hour")]
        public string ToHour { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "HouseNo")]
        public string HouseNo { get; set; }

        [Display(Name = "FlatNo")]
        public string FlatNo { get; set; }

        [Display(Name = "RoadNo")]
        public string RoadNo { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "ZipCode")]
        public int ZipCode { get; set; }
    }
}
