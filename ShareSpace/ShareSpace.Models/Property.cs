using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ShareSpace.Models
{
    public class Property
    {
        [Key]
        [Display(Name = "PropertyId")]
        [Required(ErrorMessage = "{0} is Required")]
        public Int64 PropertyId { get; set; }

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
        //[Required(AllowEmptyStrings = false, ErrorMessage = "MaximumPerson required")]
        public int MaximumPerson { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "ShortDescription")]
        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ShortDescription required")]
        public string ShortDescription { get; set; }

        [Display(Name = "FeatureImage")]
        //[Required(AllowEmptyStrings = false)]
        public string FeatureImage { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "RetaingPrice")]
        public int RetaingPrice { get; set; }

        [Display(Name = "Latitude")]
        public float Latitude { get; set; }

        [Display(Name = "Longitude")]
        public float Longitude { get; set; }

        [Display(Name = "IsFeatured")]
        public bool IsFeatured { get; set; }

        [Display(Name = "IsHidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "IsSearchable")]
        public string IsSearchable { get; set; }

        [Display(Name = "PropertyAddress")]
        public string PropertyAddress { get; set; }

        [Display(Name = "PropertyService")]
        public string PropertyService { get; set; }

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
