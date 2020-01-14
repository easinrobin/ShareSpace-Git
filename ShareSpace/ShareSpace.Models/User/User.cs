using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.User
{
    public class User
    {
        [Key]
        [Display(Name = "User ID")]
        public long UserID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

        [Display(Name = "User Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserPassword required")]
        public string UserPassword { get; set; }      

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }


    }

    [NotMapped]
    public class Role : User
    {
        [NotMapped]
        public string UserRole { get; set; }
    }
}
