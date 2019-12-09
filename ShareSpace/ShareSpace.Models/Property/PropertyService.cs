using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    [Table("PropertyService")]
    public class PropertyService
    {
        [Key]
        public long PropertyServiceId { get; set; }

        [Display(Name = "Service Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ServiceName required")]
        public int ServiceName { get; set; }

        [Display(Name = "IsHidden")]
        public int IsHidden { get; set; }

        [Display(Name = "Service Id")]
        public long ServiceId { get; set; }

        [Display(Name = "Property Id")]
        public long PropertyId { get; set; }


        [NotMapped]
        public class PropertyServiceDetails : PropertyService
        {
            public string Name { get; set; }
            [NotMapped]
            public bool IsSelected { get; set; }
        }
    }
}
