using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

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

        [Display(Name = "Client Details")]
        [Required(ErrorMessage = "Client Details required")]
        public string ClientDetails { get; set; }

        [Display(Name = "Profile Image")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Image required")]
        public string ProfileImage { get; set; }

        [Display(Name = "Message")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Message required")]
        public string Message { get; set; }

        [Display(Name = "Is Active")]
        public long IsActive { get; set; }
    }
}
