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
    }
}
