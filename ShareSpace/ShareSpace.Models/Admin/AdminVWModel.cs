using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ShareSpace.Models.Property;
using System.Web;
using ShareSpace.Models.Service;

namespace ShareSpace.Models.Admin
{
    public class AdminVWModel
    {
        public Property.Property Property { get; set; }
        public List<Property.Property> PropertyList { get; set; }
        public List<PropertyAddress> PropertyAddressList { get; set; }
        public PropertyDetails PropertyDetails { get; set; }
        public PropertyAddress PropertyAddress { get; set; }
        public PropertyRating PropertyRating { get; set; }
        public PropertyService PropertyService { get; set; }
        public List<PropertyServiceViewModel> PropertyServiceVwModel { get; set; }
        public List<PropertyService> PropertyServiceList { get; set; }
        public Gallery.Gallery Gallery { get; set; }
        public List<Gallery.Gallery> GalleryList { get; set; }
        public Services Services { get; set; }
        public Vendor.Vendor Vendors { get; set; }
        public List<Vendor.Vendor> VendorList { get; set; }
        public Testimonial.Testimonial Testimonial { get; set; }
        public Client.Client Clients { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public List<PropertyDetails> PropertyDetailsList { get; set; }
        public List<Services> ServiceList { get; set; }
        public List<PropertyWorkingDays> WorkingDaysList { get; set; }
        public PropertyWorkingDays WorkingDays { get; set; }
        //public List<ServiceType> ServiceTypes { get; set; }
        //public List<FeatureDetails> Features { get; set; }
        //public List<FacilityDetails> Facilities { get; set; }
        //public List<Gallery> Galleries { get; set; }
    }
}
