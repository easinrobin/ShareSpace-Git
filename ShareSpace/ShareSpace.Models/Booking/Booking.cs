﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Booking
{
    public class Booking
    {
        [Key]
        [Display(Name = "BookingId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "BookingId required")]
        public int BookingId { get; set; }

        [Display(Name = "FromDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/mm/yyyy")]
        public DateTime FromDate { get; set; }

        [Display(Name = "ToDate")]
        public DateTime ToDate { get; set; }

        [Display(Name = "MaximumPerson")]
        public int MaximumPerson { get; set; }

        [Display(Name = "FromHour")]
        public string FromHour { get; set; }

        [Display(Name = "ToHour")]
        public string ToHour { get; set; }

        [Display(Name = "ClientId")]
        public Int64 ClientId { get; set; }

        [Display(Name = "PropertyId")]
        public Int64 PropertyId { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "BookingNo")]
        public string BookingNo { get; set; }
    }
}
