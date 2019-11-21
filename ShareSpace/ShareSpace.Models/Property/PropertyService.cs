using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    [Table("PropertyService")]
    public class PropertyService
    {
        [Key]
        public long PropertyServiceId { get; set; }

        [Display(Name = "ServiceName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ServiceName required")]
        public int ServiceName { get; set; }

        [Display(Name = "IsHidden")]
        public int IsHidden { get; set; }

        [Display(Name = "ServiceId")]
        public int ServiceId { get; set; }

    }
}
