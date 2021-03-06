﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Property
{
    public class PropertySearchResultNew
    {
        public long PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string ShareType { get; set; }
        public string FeatureImage { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsHidden { get; set; }
        public bool IsSearchable { get; set; }
        public int Rating { get; set; }
        public int MaximumPerson { get; set; }
    }
}
