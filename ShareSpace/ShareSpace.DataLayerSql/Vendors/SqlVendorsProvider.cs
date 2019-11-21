﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer;
using ShareSpace.DataLayer.Vendor;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Vendor
{
    public class SqlVendorProvider : IVendorProvider
    {
        #region Vendor
        public long InsertVendor(Models.Vendor vendor)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTVENDORS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "ID", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var vendors in vendor.GetType().GetProperties())
                {
                    if (vendors.Name != "ID")
                    {
                        string name = vendors.Name;
                        var value = vendors.GetValue(vendor, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@ID"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Execption Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateVendor(Models.Vendor vendor)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATEVENDORS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var vendors in vendor.GetType().GetProperties())
                {
                    string name = vendors.Name;
                    var value = vendors.GetValue(vendor, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value));
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isUpdate = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isUpdate;
        }

        public List<Models.Vendor> GetAllVendors()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLVENDORS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Vendor> vendorList = new List<Models.Vendor>();
                    vendorList = UtilityManager.DataReaderMapToList<Models.Vendor>(dataReader);
                    return vendorList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public Models.Vendor GetVendorById(long vendorId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETVENDORSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@VendorId", vendorId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Vendor vendor = new Models.Vendor();
                    vendor = UtilityManager.DataReaderMap<Models.Vendor>(reader);
                    return vendor;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        

        public bool DeleteVendor(long vendorId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEVENDORS);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@VendorID", vendorId));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isDelete = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }

        #endregion

        
    }
}
