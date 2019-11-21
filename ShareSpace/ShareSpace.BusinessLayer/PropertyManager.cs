using System.Collections;
using System.Collections.Generic;
using ShareSpace.DataLayerSql.Property;
using ShareSpace.Models;

namespace ShareSpace.BusinessLayer
{
    public class PropertyManager
    {
        #region Get
        public static List<Property> GetAllPropertys()
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var allPropertys = sqlPropertyProvider.GetAllPropertys();
            return allPropertys;
        }

        public static Property GetPropertyById(long propertyId)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            return sqlPropertyProvider.GetPropertyById(propertyId);
        }


        #endregion
        #region Set
        public long InsertProperty(Property property)
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