using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    public class AdminPropertyList
    {
        [Display(Name = "Property Id")]
        public long PropertyId { get; set; }

        [Display(Name = "Vendor Id")]
        public long VendorId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        [Display(Name = "Share Type")]
        public string ShareType { get; set; }

        [Display(Name = "House No.")]
        public string HouseNo { get; set; }

        [Display(Name = "Floor/Flat No.")]
        public string FlatNo { get; set; }

        [Display(Name = "Road No.")]
        public string RoadNo { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Maximum Person")]
        public int MaximumPerson { get; set; }

        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Retail Price")]
        public decimal RetailPrice { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
