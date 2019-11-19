using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models
{
    class Gallery
    {
        [Key]
        [Display(Name = "GalleryId")]
        [Required(ErrorMessage = "{0} is Required")]
        public Int64 GalleryId { get; set; }

        [Display(Name = "ImageType")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ImageType required")]
        public char ImageType { get; set; }

        [Display(Name = "ImageUrl")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ImageUrl required")]
        public char ImageUrl { get; set; }

        [Display(Name = "Image1")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Image1 { get; set; }

        [Display(Name = "Image2")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Image2 { get; set; }

        [Display(Name = "Image3")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string Image3 { get; set; }

        [Display(Name = "PropertyId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyId required")]
        public int PropertyId { get; set; }

        [Display(Name = "CreatedBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Maximum length is {1}")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Maximum length is {1}")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime UpdateDate { get; set; }
        public int Id { get; set; }
    }
}
