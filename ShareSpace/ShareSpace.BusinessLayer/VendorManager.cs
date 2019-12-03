using System.Collections;
using System.Collections.Generic;
using ShareSpace.DataLayerSql.Vendor;
using ShareSpace.Models;

namespace ShareSpace.BusinessLayer
{
    public class VendorManager
    {
        #region Get
        public static List<Vendor> GetAllVendors(int i)
        {
            SqlVendorProvider sqlVendorProvider = new SqlVendorProvider();
            var allVendors = sqlVendorProvider.GetAllVendors();
            return allVendors;
        }

        public static Vendor GetVendorById(long vendorId)
        {
            SqlVendorProvider sqlVendorProvider = new SqlVendorProvider();
            return sqlVendorProvider.GetVendorById(vendorId);
        }

       
        #endregion
        #region Set
        public static long InsertVendor(Vendor vendor)
        {
            SqlVendorProvider sqlVendorProvider = new SqlVendorProvider();
            var id = sqlVendorProvider.InsertVendor(vendor);
            return id;
        }

        public static  bool UpdateVendor(Vendor vendor)
        {
            SqlVendorProvider sqlVendorProvider = new SqlVendorProvider();
            var isUpdate = sqlVendorProvider.UpdateVendor(vendor);
            return isUpdate;
        }

        public static bool DeleteVendor(long vendorId)
        {
            SqlVendorProvider sqlVendorProvider = new SqlVendorProvider();
            var isDelete = sqlVendorProvider.DeleteVendor(vendorId);
            return isDelete;
        }



        public static List<Vendor> GetAllVendorsByEmailNPhone( string email, string mobileNo)
        {
            SqlVendorProvider sqlVendorProvider = new SqlVendorProvider();
            var allVendors = sqlVendorProvider.GetAllVendorsByEmailNPhone(email, mobileNo);
            return allVendors;
        }
        #endregion


        
    }
}
