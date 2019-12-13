using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.User
{
    public class User
    {
        [Key]
        [Display(Name = "UserID")]
        [Required(ErrorMessage = "{0} is Required")]
        public long UserID { get; set; }

        [Display(Name = "FullName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FullName required")]
        public string FullName { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

        [Display(Name = "UserPassword")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserPassword required")]
        public string UserPassword { get; set; }      

        [Display(Name = "Mobile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile required")]
        public string Mobile { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        
    }
}
