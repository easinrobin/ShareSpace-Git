using System.Collections.Generic;
using ShareSpace.Models.Property;

namespace ShareSpace.DataLayer.Property
{
    public interface IPropertyProvider
    {
        List<FeatureProperty> GetFeatureProperties(int maxRow);
        List<PropertySearchResult> GetShareType(string type);
        List<Models.Property.Property> GetAllProperties();
        PropertyDetails GetPropertyDetailsById(int id);
        List<PropertySearchResult> GetAllPropertySearchResults();
    }
}
