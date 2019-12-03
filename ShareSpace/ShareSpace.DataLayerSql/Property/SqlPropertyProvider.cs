using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.Property;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Property;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Property
{
    public class SqlPropertyProvider : IPropertyProvider
    {
        #region GetProperty

        public List<FeatureProperty> GetFeatureProperties(int maxRow)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETFEATUREDPROPERTIES, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NumberOfProperty", maxRow));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<FeatureProperty> featurePropertiesList = new List<FeatureProperty>();
                    featurePropertiesList = UtilityManager.DataReaderMapToList<FeatureProperty>(reader);
                    return featurePropertiesList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<PropertySearchResult> GetShareType(string type)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETSHARETYPEFROMVIEW, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ShareType", type));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertySearchResult> shareTypeList = new List<PropertySearchResult>();
                    shareTypeList = UtilityManager.DataReaderMapToList<PropertySearchResult>(reader);
                    return shareTypeList;
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

        public List<Models.Property.Property> GetAllProperties()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Property.Property> propertyList = new List<Models.Property.Property>();
                    propertyList = UtilityManager.DataReaderMapToList<Models.Property.Property>(dataReader);
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

        public List<PropertySearchResult> GetAllPropertySearchResults()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLPROPERTYFROMVIEW, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertySearchResult> propertyList = new List<PropertySearchResult>();
                    propertyList = UtilityManager.DataReaderMapToList<PropertySearchResult>(reader);

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

        public PropertyDetails GetPropertyDetailsById(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETPROPERTYDETAILSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    PropertyDetails propertyDetails = new PropertyDetails();
                    propertyDetails = UtilityManager.DataReaderMap<PropertyDetails>(reader);
                    return propertyDetails;
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

        public List<ClientPropertyRating> GetClientPropertyRatings(int Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETCLIENTPROPERTYRATING, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<ClientPropertyRating> ratingList = new List<ClientPropertyRating>();
                    ratingList = UtilityManager.DataReaderMapToList<ClientPropertyRating>(reader);
                    return ratingList;
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

        public Models.Property.Property GetPropertyById(long propertyId)
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
                    Models.Property.Property property = new Models.Property.Property();
                    property = UtilityManager.DataReaderMap<Models.Property.Property>(reader);
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

        #endregion

        #region SetProperty

        public long InsertProperty(Models.Property.Property property)
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

        public bool UpdateProperty(Models.Property.Property property)
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

        public bool DeleteProperty(long propertyId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEPROPERTYS, connection);
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
