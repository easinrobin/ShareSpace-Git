using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models
{
    class PropertyRating
    {
        [Key]
        [Display(Name = "PropertyRatingId")]
        [Required(ErrorMessage = "{0} is Required")]
        public int PropertyRatingId { get; set; }

        [Display(Name = "Review")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Review required")]
        public int Review { get; set; }

        [Display(Name = "Rating")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Rating required")]
        public int Rating { get; set; }

        [Display(Name = "PropertyId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyId required")]
        public int PropertyId { get; set; }

        [Display(Name = "ClientId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ClientId required")]
        public int ClientId { get; set; }

        [Display(Name = "CreatedBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Maximum length is {1}")]
        public string CreatedBy { get; set; }

        [Display(Name = "UpdateBy")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Maximum length is {1}")]
        public string UpdateBy { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "UpdateDate")]
        public DateTime UpdateDate { get; set; }
        public int Id { get; set; }
    }
}
