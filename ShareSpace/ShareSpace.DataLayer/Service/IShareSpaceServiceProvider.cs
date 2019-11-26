using System.Collections.Generic;
using ShareSpace.Models.Service;

namespace ShareSpace.DataLayer.Service
{
    public interface IShareSpaceServiceProvider
    {
        List<FeaturedServices> GetFeaturedServices(int maxRow);
    }
}
