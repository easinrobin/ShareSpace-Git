using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.Service;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Service;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Service
{
    public class SqlServiceProvider : IShareSpaceServiceProvider
    {
        public List<FeaturedServices> GetFeaturedServices(int maxRow)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETFEATUREDSERVICE, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NumberOfServices", maxRow));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<FeaturedServices> serviceList = UtilityManager.DataReaderMapToList<FeaturedServices>(reader);
                    return serviceList;
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
