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

        public List<PropertySearchResult> GetAllProperties()
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
    }
}
