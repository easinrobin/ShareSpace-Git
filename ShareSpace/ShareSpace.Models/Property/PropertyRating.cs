using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    [Table("PropertyRating")]
    public class PropertyRating
    {
        [Key]
        public long PropertyRatingId { get; set; }

        [Display(Name = "Review")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Review required")]
        public string Review { get; set; }

        [Display(Name = "Rating")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Rating required")]
        public int Rating { get; set; }

        [Display(Name = "PropertyId")]
        public int PropertyId { get; set; }

        [Display(Name = "ClientId")]
        public int ClientId { get; set; }

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
