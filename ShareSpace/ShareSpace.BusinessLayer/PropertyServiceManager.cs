using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.DataLayerSql.Property;
using ShareSpace.DataLayerSql.Service;
using ShareSpace.Models.Property;

namespace ShareSpace.BusinessLayer
{
    public class PropertyServiceManager
    {
        public static long InsertPropertyService(PropertyService service)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.InsertPropertyService(service);
        }

        public static List<PropertyServiceViewModel> GetServicesByPropertyId(long propertyId)
        {
            SqlPropertyProvider sqlGalleryProvider = new SqlPropertyProvider();
            return sqlGalleryProvider.GetServicesByPropertyId(propertyId);
        }

        public static bool DeletePropertyServiceById(long propertyServiceId)
        {
            SqlPropertyProvider propertyProvider = new SqlPropertyProvider();
            return propertyProvider.DeletePropertyServiceById(propertyServiceId);
        }
    }
}
