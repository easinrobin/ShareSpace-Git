using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ShareSpace.Models;

namespace AdminPanel.Models
{
    public class AdminVWModel
    {
        public Property Property { get; set; }
        //public PropertyDetails PropertyDetails { get; set; }
        public PropertyAddress PropertyAddress { get; set; }
        public PropertyRating PropertyRating { get; set; }
        public PropertyService PropertyService { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }




        //public List<ServiceType> ServiceTypes { get; set; }
        //public List<FeatureDetails> Features { get; set; }
        //public List<FacilityDetails> Facilities { get; set; }
        //public List<Gallery> Galleries { get; set; }
    }

    
}