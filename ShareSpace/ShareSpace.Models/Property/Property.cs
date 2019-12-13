using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    [Table("Property")]
    public class Property
    {
        [Key]
        public long PropertyId { get; set; }

        [Display(Name = "Property Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property Name required")]
        public string PropertyName { get; set; }

        [Display(Name = "Share Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Share Type required")]
        public string ShareType { get; set; }

        [Display(Name = "Property Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property Type required")]
        public string PropertyType { get; set; }

        [Display(Name = "Maximum Person")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Maximum Person required")]
        public int MaximumPerson { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Short Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Description required")]
        public string ShortDescription { get; set; }

        [Display(Name = "Feature Image")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property Image Required")]
        public string FeatureImage { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Retail Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property Retail Required")]
        public decimal RetailPrice { get; set; }

        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }

        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }

        [Display(Name = "IsFeatured")]
        public bool IsFeatured { get; set; }

        [Display(Name = "IsHidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "IsSearchable")]
        public bool IsSearchable { get; set; }

        [Display(Name = "Vendor Id")]
        public int VendorId { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Update By")]
        public string UpdateBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }

        //[NotMapped]
        //public Vendor.Vendor Vendors { get; set; }
    }
}
