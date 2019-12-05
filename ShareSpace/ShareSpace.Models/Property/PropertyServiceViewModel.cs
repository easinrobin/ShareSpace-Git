using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Property
{
    public class PropertyServiceViewModel
    {
        [Key]
        [Display(Name = "Property Id")]
        public long PropertyId { get; set; }

        [Display(Name = "Property Service Id")]
        public long PropertyServiceId { get; set; }

        [Display(Name = "Service Id")]
        public long ServiceId { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Property Service Name")]
        public string PropertyServiceName { get; set; }

        [Display(Name = "Is Hidden Property Service")]
        public bool IsHiddenPropertyService { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Display(Name = "Is Hidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }
    }
}
