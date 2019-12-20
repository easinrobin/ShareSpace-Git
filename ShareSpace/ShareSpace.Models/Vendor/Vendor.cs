using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ShareSpace.Models.Vendor
{
    public class Vendor
    {
        [Key]
        [Display(Name = "VendorId")]
        [Required(ErrorMessage = "{0} is Required")]
        public Int64 VendorId { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Display(Name = "MobileNo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "MobileNo required")]
        public string MobileNo { get; set; }

        [Display(Name = "BirthDate")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "BirthDate required")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Display(Name = "VendorPhoto")]
        public string VendorPhoto { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [NotMapped]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
