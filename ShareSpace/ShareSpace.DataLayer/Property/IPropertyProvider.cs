using System.Collections.Generic;
using ShareSpace.Models.Property;

namespace ShareSpace.DataLayer.Property
{
    public interface IPropertyProvider
    {
        List<FeatureProperty> GetFeatureProperties(int maxRow);
    }
}
