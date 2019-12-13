using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.NewsLetter
{
    public class NewsLetter
    {
        [Key]
        [Display(Name = "NewsLetterId")]
        [Required(ErrorMessage = "{0} is Required")]
        public long NewsLetterId { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display(Name = "CreatedDate")]
        //[Required(ErrorMessage = " required")]
        public DateTime? CreatedDate { get; set; }


    }
}
