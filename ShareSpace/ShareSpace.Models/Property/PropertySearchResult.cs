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

        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        [Display(Name = "Maximum Person")]
        public int MaximumPerson { get; set; }

        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Retail Price")]
        public int RetailPrice { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Review")]
        public string Review { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Display(Name = "IsFeatured")]
        public bool IsFeatured { get; set; }

        [Display(Name = "IsHidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "IsSearchable")]
        public bool IsSearchable { get; set; }
    }
}
