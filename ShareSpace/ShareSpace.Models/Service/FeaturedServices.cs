using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Service
{
    public class FeaturedServices
    {
        [Key]
        public long ServiceId { get; set; }

        [Display(Name = "Service Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Service name required")]
        public string ServiceName { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Short Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description required")]
        public string ShortDescription { get; set; }
    }
}