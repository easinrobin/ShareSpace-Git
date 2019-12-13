using System.Collections.Generic;
using ShareSpace.DataLayerSql.Service;
using ShareSpace.Models.Property;
using ShareSpace.Models.Service;

namespace ShareSpace.BusinessLayer
{
    public class ServiceManager
    {
        public static List<FeaturedServices> GetFeaturedServices(int maxRow)
        {
            SqlServiceProvider serviceProvider = new SqlServiceProvider();
            return serviceProvider.GetFeaturedServices(maxRow);
        }

        public static List<Services> GetAllServices()
        {
            SqlServiceProvider serviceProvider = new SqlServiceProvider();
            return serviceProvider.GetAllServices();
        }
    }
}
