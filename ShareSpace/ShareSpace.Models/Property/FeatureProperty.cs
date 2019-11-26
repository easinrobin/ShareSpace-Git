using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Property
{
    public class FeatureProperty
    {
        [Key]
        public long PropertyId { get; set; }
        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }
        [Display(Name = "Retail Price")]
        public int RetailPrice { get; set; }
        [Display(Name = "Rating")]
        public int Rating { get; set; }
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
    }
}
