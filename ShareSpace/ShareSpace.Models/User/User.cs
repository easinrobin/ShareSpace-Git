using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.User
{
    public class User
    {
        [Key]
        [Display(Name = "UserID")]
        public long UserID { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

        [Display(Name = "UserPassword")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserPassword required")]
        public string UserPassword { get; set; }      

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [NotMapped]
        public string UserRole { get; set; }
    }
}
