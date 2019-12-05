using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.Models.Property;

namespace ShareSpace.Models.Client
{
    public class ClientViewModel
    {
        public List<PropertyServiceViewModel> PropertyServiceList { get; set; }
        public List<PropertySearchResultNew> PropertySearchResultList { get; set; }
    }
}
