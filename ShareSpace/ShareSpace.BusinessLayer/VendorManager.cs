using System.Collections.Generic;
using ShareSpace.DataLayerSql.Vendor;
using ShareSpace.Models.Property;
using ShareSpace.Models.Vendor;

namespace ShareSpace.BusinessLayer
{
    public class VendorManager
    {
        #region Get
        public static List<Vendor> GetAllVendors()
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var allVendors = sqlVendorProvider.GetAllVendors();
            return allVendors;
        }

        public static Vendor GetVendorById(long vendorId)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            return sqlVendorProvider.GetVendorById(vendorId);
        }

        public static List<Property> GetVendorsPropertyById(long vendorId)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            return sqlVendorProvider.GetVendorsPropertyById(vendorId);
        }

        public static List<Vendor> GetAllVendorsByEmailNPhone(string email, string mobileNo)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var allVendors = sqlVendorProvider.GetAllVendorsByEmailNPhone(email, mobileNo);
            return allVendors;
        }

        public static Vendor GetVendorByEmailPassword(string email, string password)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var allVendors = sqlVendorProvider.GetVendorByEmailPassword(email, password);
            return allVendors;
        }

        #endregion


        #region Set
        public static long InsertVendor(Vendor vendor)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var id = sqlVendorProvider.InsertVendor(vendor);
            return id;
        }

        public static bool UpdateVendor(Vendor vendor)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var isUpdate = sqlVendorProvider.UpdateVendor(vendor);
            return isUpdate;
        }

        public static bool DeleteVendor(long vendorId)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var isDelete = sqlVendorProvider.DeleteVendor(vendorId);
            return isDelete;
        }

        public static bool HideVendor(long vendorId)
        {
            SqlVendorsProvider sqlVendorProvider = new SqlVendorsProvider();
            var isDelete = sqlVendorProvider.HideVendor(vendorId);
            return isDelete;
        }

        #endregion
    }
}
