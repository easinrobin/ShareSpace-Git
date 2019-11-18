using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models;
using ShareSpace.Utility;


namespace ShareSpace.DataLayerSql.Vendors
{
    class SqlVendorsProvider : IVendorProvider
    {
        public List<Vendor> GetAllVendors()
        {
            List<Vendor> vendorList = new List<Vendor>();
            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.GETALLVENDORS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Models.Vendor vendor = new Models.Vendor();
                        vendor.Id = (int)dataReader["Id"];
                        vendor.FirstName = dataReader["FirstName"].ToString();
                        vendor.LastName = dataReader["LastName"].ToString();
                        vendor.Email = dataReader["Email"].ToString();
                        vendor.Country = dataReader["Country"].ToString();
                        vendor.MobileNo = dataReader["MobileNo"].ToString();
                        vendor.BirthDate = (DateTime)dataReader["BirthDate"];
                        vendor.Password = dataReader["Password"].ToString();
                        vendor.VendorPhoto = dataReader["VendorPhoto"].ToString();
                        vendor.CreatedBy = dataReader["CreatedBy"].ToString();
                        vendor.UpdateBy = dataReader["UpdateBy"].ToString();
                        vendor.CreatedDate = (DateTime)dataReader["CreatedDate"];
                        vendor.UpdateDate = (DateTime)dataReader["UpdateDate"];

                        vendorList.Add(vendor);
                    }
                    dataReader.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }

                finally
                {
                    sqlConnection.Close();
                }
            }
            
            return vendorList;
        }


        public List<Models.Vendor> GetVendorById(long Id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                List<Models.Vendor> vendorList = new List<Models.Vendor>();
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.GETVENDORBYID, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@ID", Id));

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    Models.Vendor vendor = new Models.Vendor();
                    vendor = UtilityManager.DataReaderMap<Models.Vendor>(reader);
                    vendorList.Add(vendor);
                    return vendorList;

                    //while (reader.Read())
                    //{
                    //    Models.Client client = new Models.Client();
                    //    client.ClientId = (int)reader["ClientId"];
                    //    client.FirstName = reader["FirstName"].ToString();
                    //    client.LastName = reader["LastName"].ToString();
                    //    client.Email = reader["Email"].ToString();
                    //    client.Country = reader["Country"].ToString();
                    //    client.MobileNo = reader["MobileNo"].ToString();
                    //    client.BirthDate = (DateTime)reader["BirthDate"];
                    //    client.Password = reader["Password"].ToString();
                    //    client.ClientPhoto = reader["ClientPhoto"].ToString();
                    //    client.CreatedBy = reader["CreatedBy"].ToString();
                    //    client.UpdateBy = reader["UpdateBy"].ToString();
                    //    client.CreatedDate = (DateTime)reader["CreatedDate"];
                    //    client.UpdateDate = (DateTime)reader["UpdateDate"];

                    //    clientList.Add(client);
                    //    return clientList;
                    //}
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

        }

        public static long Add(Models.Vendor vendor)
        {
            long id = 0;
            using (SqlConnection conn = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(StoreProcedure.INSERTVENDORS, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(returnValue);
                foreach (var property in vendor.GetType().GetProperties())
                {
                    if (property.Name != "Id")
                    {
                        string name = property.Name;
                        var value = property.GetValue(vendor, null);
                        cmd.Parameters.Add(new SqlParameter("@" + name, value));
                    }
                }
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    id = (int)cmd.Parameters["@Id"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Execption Adding Data. " + ex.Message);
                }
                finally
                {
                    conn.Close();

                }
            }
            return id;
        }

        public bool InsertVendor(Models.Vendor vendor)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.INSERTVENDORS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("FirstName", vendor.FirstName);
                sqlCommand.Parameters.AddWithValue("LastName", vendor.LastName);
                sqlCommand.Parameters.AddWithValue("Email", vendor.Email);
                sqlCommand.Parameters.AddWithValue("Country", vendor.Country);
                sqlCommand.Parameters.AddWithValue("MobileNo", vendor.MobileNo);
                sqlCommand.Parameters.AddWithValue("BirthDate", vendor.BirthDate);
                sqlCommand.Parameters.AddWithValue("Password", vendor.Password);
                sqlCommand.Parameters.AddWithValue("CreatedBy", vendor.CreatedBy);
                sqlCommand.Parameters.AddWithValue("UpdateBy", vendor.UpdateBy);
                sqlCommand.Parameters.AddWithValue("CreatedDate", vendor.CreatedDate);
                sqlCommand.Parameters.AddWithValue("UpdateDate", vendor.UpdateDate);

                try
                {
                    sqlConnection.Open();
                    int rowEffect = sqlCommand.ExecuteNonQuery();
                    if (rowEffect > 0)
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews." + e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return false;
        }

        public bool UpdateClient(Models.Vendor vendor)
        {
            bool isUpdate = false;

            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.UPDATEVENDORS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (var vendors in vendor.GetType().GetProperties())
                {
                    string name = vendors.Name;
                    var value = vendors.GetValue(vendor, null);
                    sqlCommand.Parameters.Add(new SqlParameter("@Id" + name, value));
                }

                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isUpdate = true;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return isUpdate;
        }


        public bool DeleteVendor(Models.Vendor vendor)
        {
            bool isDelete = false;
            long Id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEVENDORS);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", Id));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isDelete = true;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }

       
    }
}

