using System.Collections.Generic;
using ShareSpace.DataLayerSql.Property;
using ShareSpace.Models.Property;

namespace ShareSpace.BusinessLayer
{
    public class PropertyWorkingDaysManager
    {
        public static long InsertPropertyWorkingDays(PropertyWorkingDays workingDays)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var id = sqlPropertyProvider.InsertPropertyWorkingDays(workingDays);
            return id;
        }

        public static bool UpdatePropertyWorkingDays(PropertyWorkingDays workingDays)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var isUpdate = sqlPropertyProvider.UpdatePropertyWorkingDays(workingDays);
            return isUpdate;
        }

        public static bool DeletePropertyWorkingDays(long id)
        {
            SqlPropertyProvider sqlPropertyProvider = new SqlPropertyProvider();
            var isDelete = sqlPropertyProvider.DeleteProperty(id);
            return isDelete;
        }

        public static List<PropertyWorkingDays> GetAllPropertyWorkingDays()
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetAllPropertyWorkingDays();
        }

        public static PropertyWorkingDays GetAllPropertyWorkingDaysByPropertyId(long id)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.GetPropertyWorkingDaysByPropertyId(id);
        }
    }
}
