using System.Collections.Generic;
using ShareSpace.DataLayerSql.Property;
using ShareSpace.Models.Property;

namespace ShareSpace.BusinessLayer
{
    public class PropertyManager
    {
        public static List<FeatureProperty> GetFeaturedProperties(int maxRow)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetFeatureProperties(maxRow);
        }

        public static List<Property> GetShareType(string type)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetShareType(type);
        }
    }
}
