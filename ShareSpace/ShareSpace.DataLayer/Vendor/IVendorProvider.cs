using System.Collections.Generic;

namespace ShareSpace.DataLayer.Vendor
{
    public interface IVendorProvider
    {
        List<Models.Vendor.Vendor> GetAllVendors();
    }
}
