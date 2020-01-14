using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpace.Models.Property
{
    public class PropertyWorkingDays
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "Saturday")]
        public bool Sat { get; set; }

        [Display(Name = "Sunday")]
        public bool Sun { get; set; }

        [Display(Name = "Monday")]
        public bool Mon { get; set; }

        [Display(Name = "Tuesday")]
        public bool Tue { get; set; }

        [Display(Name = "Wednesday")]
        public bool Wed { get; set; }

        [Display(Name = "Thursday")]
        public bool Thu { get; set; }

        [Display(Name = "Friday")]
        public bool Fri { get; set; }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        [Display(Name = "End Time")]
        public string EndTime { get; set; }

        [Display(Name = "Property Id")]
        public long PropertyId { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Update By")]
        public string UpdateBy { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? UpdateDate { get; set; }
    }
}
