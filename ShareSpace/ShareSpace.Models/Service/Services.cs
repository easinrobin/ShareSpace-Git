using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Service
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public long ServiceId { get; set; }

        [Display(Name = "Service Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Service name required")]
        public string ServiceName { get; set; }

        [Display(Name = "IsHidden")]
        public string IsHidden { get; set; }

        [Display(Name = "IsFeatured")]
        public string IsFeatured { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Short Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description required")]
        public string ShortDescription { get; set; }

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
