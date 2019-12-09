using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Property
{
    [Table("PropertyAddress")]
    public class PropertyAddress
    {
        [Key]
        public long PropertyAddressId { get; set; }

        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "City required")]
        public string City { get; set; }

        [Display(Name = "Area")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Area required")]
        public string Area { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address required")]
        public string Address { get; set; }

        [Display(Name = "ZipCode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Zip code required")]
        public int ZipCode { get; set; }

        [Display(Name = "Property Id")]
        public long PropertyId { get; set; }

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
