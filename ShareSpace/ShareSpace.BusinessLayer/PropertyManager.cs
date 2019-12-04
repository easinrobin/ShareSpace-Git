using System.Collections.Generic;
using ShareSpace.DataLayerSql.Property;
using ShareSpace.Models.Property;

namespace ShareSpace.BusinessLayer
{
    public class PropertyManager
    {
        #region Get

        public static List<FeatureProperty> GetFeaturedProperties(int maxRow)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetFeatureProperties(maxRow);
        }

        public static List<PropertySearchResultNew> GetShareType(string type)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetShareType(type);
        }

        public static List<PropertySearchResult> GetAllPropertySearchResults()
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetAllPropertySearchResults();
        }

        public static List<Property> GetAllProperties()
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetAllProperties();
        }
        
        public static List<PropertySearchResultNew> GetPropertiesAndPropertyRating()
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetPropertiesAndPropertyRating();
        }

        public static PropertyDetails GetPropertyDetailsById(int id)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetPropertyDetailsById(id);
        }

        public static List<ClientPropertyRating> PropertyRatings(int Id)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetClientPropertyRatings(Id);
        }

        public static Property GetPropertyById(long propertyId)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetPropertyById(propertyId);
        }

        public static List<PropertyServiceViewModel> GetPropertyServicesOnClient(long propertyId)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetPropertyServicesOnClient(propertyId);
        }

        public static List<PropertyServiceViewModel> GetPropertyServiceByPropertyIds(string ids)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetPropertyServiceByPropertyIds(ids);
        }
        #endregion


        #region Set

        public static long InsertProperty(Property property)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var id = sqlPropertyProvider.InsertProperty(property);
            return id;
        }

        public static bool UpdateProperty(Property property)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var isUpdate = sqlPropertyProvider.UpdateProperty(property);
            return isUpdate;
        }

        public static bool DeleteProperty(long PropertyId)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var isDelete = sqlPropertyProvider.DeleteProperty(PropertyId);
            return isDelete;
        }

        #endregion
    }
}
