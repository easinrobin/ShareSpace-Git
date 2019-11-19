using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models
{
    class PropertyService
    {
        [Key]
        [Display(Name = "PropertyServiceId")]
        [Required(ErrorMessage = "{0} is Required")]
        public int PropertyServiceId { get; set; }

        [Display(Name = "ServiceName")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "ServiceName required")]
        public int ServiceName { get; set; }

        [Display(Name = "IsHidden")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "IsHidden required")]
        public int IsHidden { get; set; }

        [Display(Name = "ServiceId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ServiceId required")]
        public int ServiceId { get; set; }

        
    }
}
