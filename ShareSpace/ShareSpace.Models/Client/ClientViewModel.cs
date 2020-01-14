using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ShareSpace.Models.Property;
using ShareSpace.Models.Search;
using ShareSpace.Models.Booking;
namespace ShareSpace.Models.Client
{
    public class ClientViewModel
    {
        public List<PropertyServiceViewModel> PropertyServiceList { get; set; }
        public List<PropertySearchResultNew> PropertySearchResultList { get; set; }
        public PropertySearchResultNew PropertySearchResult { get; set; }
        public Booking.Booking Booking { get; set; }
        public OfficeSearch OfficeSearch { get; set; }
        public List<ClientPropertyRating> ClientPropertyRatings { get; set; }
        public PropertyView PropertyView { get; set; }
        public List<PropertyServiceViewModel> PropertyServiceOnClient { get; set; }
        public List<Gallery.Gallery> GalleryList { get; set; }
        public BookingEmail BookingEmail { get; set; }
        public Client Client { get; set; }
        public NewsLetter.NewsLetter NewsLetter { get; set; }
        public PropertyRating PropertyRating { get; set; }
        public PropertyWorkingDays PropertyWorkingDays { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image Required")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
