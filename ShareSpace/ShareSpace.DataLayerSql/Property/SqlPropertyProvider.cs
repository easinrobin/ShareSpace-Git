using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer;
using ShareSpace.DataLayer.Property;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Property
{
    public class SqlPropertyProvider : IPropertyProvider
    {
        #region Property
        public long InsertProperty(Models.Property property)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "PropertyId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var propertys in property.GetType().GetProperties())
                {
                    if (propertys.Name != "PropertyId")
                    {
                        string name = propertys.Name;
                        var value = propertys.GetValue(property, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@PropertyId"].Value;
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

        public bool UpdateProperty(Models.Property property)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATEPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var propertys in property.GetType().GetProperties())
                {
                    string name = propertys.Name;
                    var value = propertys.GetValue(property, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
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

        public List<Models.Property> GetAllPropertys()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Property> propertyList = new List<Models.Property>();
                    propertyList = UtilityManager.DataReaderMapToList<Models.Property>(dataReader);
                    return propertyList;
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

        public Models.Property GetPropertyById(long propertyId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETPROPERTYSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", propertyId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Property property = new Models.Property();
                    property = UtilityManager.DataReaderMap<Models.Property>(reader);
                    return property;
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



        public bool DeleteProperty(long propertyId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEPROPERTYS,connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyID", propertyId));

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
