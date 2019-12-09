using System.Collections.Generic;
using ShareSpace.Models.Property;
using System.Web;
using ShareSpace.Models.Service;

namespace ShareSpace.Models.Admin
{
    public class AdminVWModel
    {
        public Property.Property Property { get; set; }
        public PropertyDetails PropertyDetails { get; set; }
        public PropertyAddress PropertyAddress { get; set; }
        public PropertyRating PropertyRating { get; set; }
        public PropertyService PropertyService { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public List<PropertyDetails> PropertyDetailsList { get; set; }
        public List<Services> ServiceList { get; set; }
        //public List<ServiceType> ServiceTypes { get; set; }
        //public List<FeatureDetails> Features { get; set; }
        //public List<FacilityDetails> Facilities { get; set; }
        //public List<Gallery> Galleries { get; set; }
    }
}
