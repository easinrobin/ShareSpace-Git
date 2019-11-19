using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models
{
    class PropertyAddress
    {
        [Key]
        [Display(Name = "PropertyAddressId")]
        [Required(ErrorMessage = "{0} is Required")]
        public Int64 PropertyAddressId { get; set; }

        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country required")]
        public char Country { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City required")]
        public char City { get; set; }

        [Display(Name = "Area")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Area required")]
        public char Area { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address required")]
        public char Address { get; set; }

        [Display(Name = "ZipCode")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public int ZipCode { get; set; }

        
    }
}
