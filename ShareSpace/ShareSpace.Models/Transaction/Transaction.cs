using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Transaction
{
    public class Transaction
    {
        [Key]
        [Display(Name = "TransactionId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "TransactionId required")]
        public int TransactionId { get; set; }

        [Display(Name = "TotalPrice")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "TotalPrice required")]
        public int TotalPrice { get; set; }

        [Display(Name = "VendorId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "VendorId required")]
        public int VendorId { get; set; }

        [Display(Name = "PropertyId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyId required")]
        public int PropertyId { get; set; }

        [Display(Name = "PropertyRatingId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "PropertyRatingId required")]
        public int PropertyRatingId { get; set; }
    }
}
