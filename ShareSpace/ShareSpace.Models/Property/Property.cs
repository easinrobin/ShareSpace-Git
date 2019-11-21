﻿using System;
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
        public char PropertyName { get; set; }

        [Display(Name = "ShareType")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ShareType required")]
        public char ShareType { get; set; }

        [Display(Name = "PropertyType")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyType required")]
        public char PropertyType { get; set; }

        [Display(Name = "MaximumPerson")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "MaximumPerson required")]
        public int MaximumPerson { get; set; }

        [Display(Name = "FeatureImage")]
        [Required(AllowEmptyStrings = false)]
        public string FeatureImage { get; set; }

        [Display(Name = "Description")]
        public char Description { get; set; }

        [Display(Name = "ShortDescription")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ShortDescription required")]
        public char ShortDescription { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "RetailPrice")]
        public int RetailPrice { get; set; }

        [Display(Name = "Latitude")]
        public float Latitude { get; set; }

        [Display(Name = "Longitude")]
        public float Longitude { get; set; }

        [Display(Name = "IsFeatured")]
        public string IsFeatured { get; set; }

        [Display(Name = "IsHidden")]
        public string IsHidden { get; set; }

        [Display(Name = "IsSearchable")]
        public string IsSearchable { get; set; }

        [Display(Name = "PropertyAddressId")]
        public int PropertyAddressId { get; set; }

        [Display(Name = "PropertyServiceId")]
        public int PropertyServiceId { get; set; }

        [Display(Name = "VendorId")]
        public int VendorId { get; set; }

        [Display(Name = "CreatedBy")]
        public char CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        public char UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }
    }
}