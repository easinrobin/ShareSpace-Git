using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.Models.Property;
using ShareSpace.Models.Search;

namespace ShareSpace.Models.Client
{
    public class ClientViewModel
    {
        public List<PropertyServiceViewModel> PropertyServiceList { get; set; }
        public List<PropertySearchResultNew> PropertySearchResultList { get; set; }
        public PropertySearchResultNew PropertySearchResult { get; set; }
        public Booking.Booking Booking { get; set; }
        public OfficeSearch OfficeSearch { get; set; }
    }
}
