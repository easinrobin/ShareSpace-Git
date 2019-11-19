using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models
{
    class Services
    {
        [Key]
        [Display(Name = "ServiceId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ServiceId required")]
        public int ServiceId { get; set; }

        [Display(Name = "ServiceName")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "ServiceName required")]
        public int ServiceName { get; set; }

        [Display(Name = "IsHidden")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "IsHidden required")]
        public int IsHidden { get; set; }

        [Display(Name = "IsFeatured")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "IsHidden required")]
        public int IsFeatured { get; set; }

        [Display(Name = "CreatedBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Created length is {1}")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Created length is {1}")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime UpdateDate { get; set; }
        public int Id { get; set; }
    }
}
