using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.DataLayerSql.Address;
using ShareSpace.Models.Property;

namespace ShareSpace.BusinessLayer
{
    public class AddressManager
    {
        #region Get
        public static List<PropertyAddress> GetAllAddresss()
        {
            SqlAddressProvider sqlAddressProvider = new SqlAddressProvider();
            var allAddresss = sqlAddressProvider.GetAllAddresss();
            return allAddresss;
        }

        public static PropertyAddress GetAddressById(long addressId)
        {
            SqlAddressProvider sqlAddressProvider = new SqlAddressProvider();
            return sqlAddressProvider.GetAddressById(addressId);
        }

        public static PropertyAddress GetAddressByPropertyId(long propertyId)
        {
            SqlAddressProvider sqlAddressProvider = new SqlAddressProvider();
            return sqlAddressProvider.GetAddressByPropertyId(propertyId);
        }
        #endregion


        #region Set
        public static long InsertAddress(Models.Property.PropertyAddress address)
        {
            SqlAddressProvider sqlAddressProvider = new SqlAddressProvider();
            var id = sqlAddressProvider.InsertAddress(address);
            return id;
        }

        public static bool UpdateAddress(PropertyAddress address)
        {
            SqlAddressProvider sqlAddressProvider = new SqlAddressProvider();
            var isUpdate = sqlAddressProvider.UpdateAddress(address);
            return isUpdate;
        }

        public static bool DeleteAddress(long addressId)
        {
            SqlAddressProvider sqlAddressProvider = new SqlAddressProvider();
            var isDelete = sqlAddressProvider.DeleteAddress(addressId);
            return isDelete;
        }

        #endregion
    }
}
