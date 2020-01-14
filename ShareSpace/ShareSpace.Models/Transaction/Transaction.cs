using System.ComponentModel.DataAnnotations;

namespace ShareSpace.Models.Transaction
{
    public class Transaction
    {
        [Key]
        [Display(Name = "Transaction Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Transaction required")]
        public int TransactionId { get; set; }

        [Display(Name = "Total Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Total Price required")]
        public int TotalPrice { get; set; }

        [Display(Name = "Vendor Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vendor required")]
        public int VendorId { get; set; }

        [Display(Name = "Property Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property required")]
        public int PropertyId { get; set; }

        [Display(Name = "Property Rating Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Property Rating required")]
        public int PropertyRatingId { get; set; }
    }
}
