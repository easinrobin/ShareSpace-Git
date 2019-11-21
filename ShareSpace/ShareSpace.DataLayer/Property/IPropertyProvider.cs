using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.Models.Property;

namespace ShareSpace.DataLayer.Property
{
    public interface IPropertyProvider
    {
        List<FeatureProperty> GetFeatureProperties(int maxRow);
    }
}
