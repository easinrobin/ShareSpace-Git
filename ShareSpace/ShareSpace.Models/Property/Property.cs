using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    [Table("Property")]
    public class Property
    {
        [Key]
        public long PropertyId { get; set; }

        [Display(Name = "PropertyName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyName name required")]
        public string PropertyName { get; set; }

        [Display(Name = "ShareType")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ShareType required")]
        public string ShareType { get; set; }

        [Display(Name = "PropertyType")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyType required")]
        public string PropertyType { get; set; }

        [Display(Name = "MaximumPerson")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "MaximumPerson required")]
        public int MaximumPerson { get; set; }

        [Display(Name = "FeatureImage")]
        [Required(AllowEmptyStrings = false)]
        public string FeatureImage { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "ShortDescription")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ShortDescription required")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "RetailPrice")]
        public int RetailPrice { get; set; }

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

        [Display(Name = "PropertyAddressId")]
        public int PropertyAddressId { get; set; }

        [Display(Name = "PropertyServiceId")]
        public int PropertyServiceId { get; set; }

        [Display(Name = "VendorId")]
        public int VendorId { get; set; }

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
