using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.Client;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Client
{
    public class SqlClientProvider : IClientProvider
    {
        #region Client
        public long InsertClient(Models.Client client)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTCLIENT, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "ClientId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var clients in client.GetType().GetProperties())
                {
                    if (clients.Name != "ClientId")
                    {
                        string name = clients.Name;
                        var value = clients.GetValue(client, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@ClientId"].Value;
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

        public bool UpdateClient(Models.Client client)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATECLIENT, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var clients in client.GetType().GetProperties())
                {
                    string name = clients.Name;
                    var value = clients.GetValue(client, null);
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

        public List<Models.Client> GetAllClients()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLCLIENT, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Client> clientList = new List<Models.Client>();
                    clientList = UtilityManager.DataReaderMapToList<Models.Client>(dataReader);
                    return clientList;
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

        public Models.Client GetClientById(long clientId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETCLIENTBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientId", clientId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Client client = new Models.Client();
                    client = UtilityManager.DataReaderMap<Models.Client>(reader);
                    return client;
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

        //public Models.Client GetClientByEmail(string email)
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(StoreProcedure.GETCLIENTBYEMAIL);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@Email", email));

        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            Models.Client client = new Models.Client();
        //            client = UtilityManager.DataReaderMap<Models.Client>(reader);
        //            return client;
        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception("Exception retrieving reviews. " + e.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}

        public bool DeleteClient(long clientId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETECLIENT, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientID", clientId));

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
