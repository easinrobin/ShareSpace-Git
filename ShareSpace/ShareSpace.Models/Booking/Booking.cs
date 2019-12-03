using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //[Required(AllowEmptyStrings = false, ErrorMessage = "FromDate required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/mm/yyyy")]
        public DateTime? FromDate { get; set; }

        [Display(Name = "ToDate")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "ToDate required")]
        public DateTime? ToDate { get; set; }

        [Display(Name = "MaximumPerson")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "MaximumPerson required")]
        public int MaximumPerson { get; set; }

        [Display(Name = "FromHour")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "FromHour required")]
        public DateTime? FromHour { get; set; }

        [Display(Name = "ToHour")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "ToHour required")]
        public DateTime? ToHour { get; set; }

        [Display(Name = "ClientId")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "ClientId required")]
        public int ClientId { get; set; }


        [Display(Name = "PropertyId")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "PropertyId required")]
        public int PropertyId { get; set; }

        [Display(Name = "CreatedBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Maximum length is {1}")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Maximum length is {1}")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }

    }
}
