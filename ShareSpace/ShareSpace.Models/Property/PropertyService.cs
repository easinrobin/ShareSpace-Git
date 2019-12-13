using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShareSpace.Models.Service;

namespace ShareSpace.Models.Property
{
    [Table("PropertyService")]
    public class PropertyService
    {
        [Key]
        public long PropertyServiceId { get; set; }

        [Display(Name = "Service Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ServiceName required")]
        public string ServiceName { get; set; }

        [Display(Name = "IsHidden")]
        public int IsHidden { get; set; }

        [Display(Name = "Service Id")]
        public long ServiceId { get; set; }

        [Display(Name = "Property Id")]
        public long PropertyId { get; set; }
        
    }


}
