using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Property
{
    public class PropertySearchResult
    {
        [Key]
        public long PropertyId { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Share Type")]
        public string ShareType { get; set; }

        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Retail Price")]
        public int RetailPrice { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "IsFeatured")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }
        
        [Display(Name = "Property Service Name")]
        public string PropertyServiceName { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Display(Name = "Service Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "IsHidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "IsSearchable")]
        public bool IsSearchable { get; set; }
    }
}
