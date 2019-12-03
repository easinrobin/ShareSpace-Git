using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Gallery
{
    [Table("Gallery")]
    public class Gallery
    {
        [Key]
        public long GalleryId { get; set; }

        [Display(Name = "ImageType")]
        public string ImageType { get; set; }

        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        [Display(Name = "Image1")]
        public string Image1 { get; set; }

        [Display(Name = "Image2")]
        public string Image2 { get; set; }

        [Display(Name = "Image3")]
        public string Image3 { get; set; }

        [Display(Name = "Image4")]
        public string Image4 { get; set; }

        [Display(Name = "Image5")]
        public string Image5 { get; set; }

        [Display(Name = "Image6")]
        public string Image6 { get; set; }

        [Display(Name = "PropertyId")]
        public int PropertyId { get; set; }

        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }
    }
}
