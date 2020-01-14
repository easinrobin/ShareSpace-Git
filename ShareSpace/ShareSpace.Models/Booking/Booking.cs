using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Booking
{
    public class Booking
    {
        [Key]
        [Display(Name = "Booking Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "BookingId required")]
        public int BookingId { get; set; }

        [Display(Name = "From Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "From Date required")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "To Date required")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Maximum Person")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Maximum person required")]
        public int MaximumPerson { get; set; }

        [Display(Name = "From Hour")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Start Time required")]
        public string FromHour { get; set; }

        [Display(Name = "To Hour")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "End Time required")]
        public string ToHour { get; set; }

        [Display(Name = "Client Id")]
        public Int64 ClientId { get; set; }

        [Display(Name = "Property Id")]
        public Int64 PropertyId { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Display(Name = "BookingNo")]
        public string BookingNo { get; set; }
    }
}
