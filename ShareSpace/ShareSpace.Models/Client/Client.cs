using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Client
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public long ClientId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Maximum 8 digit")]
        public string Password { get; set; }

        [Display(Name = "Client Photo")]
        public string ClientPhoto { get; set; }

        [Display(Name = "Is InActive")]
        public bool IsInActive { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Update By")]
        public string UpdateBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}
