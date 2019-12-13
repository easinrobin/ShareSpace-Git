using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Testimonial
{
    public class Testimonial
    {
        [Key]
        [Display(Name = "TestimonialId")]
        [Required(ErrorMessage = "{0} is Required")]
        public long TestimonialId { get; set; }

        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Display(Name = "ClientDetails")]
        [Required(ErrorMessage = "ClientDetails required")]
        public string ClientDetails { get; set; }

        [Display(Name = "ProfileImage")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Image required")]
        public string ProfileImage { get; set; }

        [Display(Name = "Message")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "  required")]
        public string Message { get; set; }

        [Display(Name = "IsActive")]
        public long IsActive { get; set; }
    }
}
