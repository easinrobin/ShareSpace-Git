using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShareSpace.Models.Booking;

namespace ShareSpace.Models.Property
{
    public class PropertyDetails
    {
        [Key]
        [Display(Name = "PropertyId")]
        public long PropertyId { get; set; }

        [Display(Name = "GalleryId")]
        public int GalleryId { get; set; }

        [Display(Name = "PropertyAddressId")]
        public int PropertyAddressId { get; set; }

        [Display(Name = "PropertyServiceId")]
        public int PropertyServiceId { get; set; }

        [Display(Name = "ServiceId")]
        public int ServiceId { get; set; }

        [Display(Name = "PropertyRatingId")]
        public int PropertyRatingId { get; set; }
        
        [Display(Name = "ClientId")]
        public int ClientId { get; set; }

        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }

        [Display(Name = "Share Type")]
        public string ShareType { get; set; }

        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        [Display(Name = "Feature Image")]
        public string FeatureImage { get; set; }

        [Display(Name = "Maximum Person")]
        public int MaximumPerson { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Retail Price")]
        public decimal RetailPrice { get; set; }

        [Display(Name = "Latitude")]
        public float Latitude { get; set; }

        [Display(Name = "Longitude")]
        public float Longitude { get; set; }

        [Display(Name = "IsHidden")]
        public bool IsHidden { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Client Photo")]
        public string ClientPhoto { get; set; }

        [Display(Name = "Image Type")]
        public string ImageType { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Image1")]
        public string Image1 { get; set; }

        [Display(Name = "Image2")]
        public string Image2 { get; set; }

        [Display(Name = "Image3")]
        public string Image3 { get; set; }

        [Display(Name = "Image4")]
        public string Image4 { get; set; }

        [Display(Name = "Image5")]
        public string Image5 { get; set; }

        [Display(Name = "Image6")]
        public string Image6 { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "ZipCode")]
        public int ZipCode { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Review")]
        public string Review { get; set; }

        [Display(Name = "ServiceName")]
        public string ServiceName { get; set; }

        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }

        [NotMapped]
        public List<ClientPropertyRating> ClientPropertyRatings { get; set; }
        [NotMapped]
        public BookingEmail BookingEmail { get; set; }
        [NotMapped]
        public List<PropertyServiceViewModel> PropertyServiceOnClient { get; set; }
    }
}
