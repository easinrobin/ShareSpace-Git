using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace;
using ShareSpace.DataLayer.Client;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Client
{
    public class SqlClientProvider : IClientProvider
    {
        public List<Models.Client> GetAllClients()
        {
            List<Models.Client> clientList = new List<Models.Client>();
            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.GETALLCLIENT, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Models.Client client = new Models.Client();
                        client.ClientId = (int)dataReader["ClientId"];
                        client.FirstName = dataReader["FirstName"].ToString();
                        client.LastName = dataReader["LastName"].ToString();
                        client.Email = dataReader["Email"].ToString();
                        client.Country = dataReader["Country"].ToString();
                        client.MobileNo = dataReader["MobileNo"].ToString();
                        client.BirthDate = (DateTime)dataReader["BirthDate"];
                        client.Password = dataReader["Password"].ToString();
                        client.ClientPhoto = dataReader["ClientPhoto"].ToString();
                        client.CreatedBy = dataReader["CreatedBy"].ToString();
                        client.UpdateBy = dataReader["UpdateBy"].ToString();
                        client.CreatedDate = (DateTime)dataReader["CreatedDate"];
                        client.UpdateDate = (DateTime)dataReader["UpdateDate"];

                        clientList.Add(client);
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
            return clientList;
        }

        public List<Models.Client> GetClientById(long clientId)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                List<Models.Client> clientList = new List<Models.Client>();
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.GETCLIENTBYID, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@ClientId", clientId));

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    Models.Client client = new Models.Client();
                    client = UtilityManager.DataReaderMap<Models.Client>(reader);
                    clientList.Add(client);
                    return clientList;

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

        public static long Add(Models.Client client)
        {
            long id = 0;
            using (SqlConnection conn = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(StoreProcedure.INSERTCLIENT, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(returnValue);
                foreach (var property in client.GetType().GetProperties())
                {
                    if (property.Name != "Id")
                    {
                        string name = property.Name;
                        var value = property.GetValue(client, null);
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

        public bool InsertClient(Models.Client client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.INSERTCLIENT, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("FirstName", client.FirstName);
                sqlCommand.Parameters.AddWithValue("LastName", client.LastName);
                sqlCommand.Parameters.AddWithValue("Email", client.Email);
                sqlCommand.Parameters.AddWithValue("Country", client.Country);
                sqlCommand.Parameters.AddWithValue("MobileNo", client.MobileNo);
                sqlCommand.Parameters.AddWithValue("BirthDate", client.BirthDate);
                sqlCommand.Parameters.AddWithValue("Password", client.Password);
                sqlCommand.Parameters.AddWithValue("CreatedBy", client.CreatedBy);
                sqlCommand.Parameters.AddWithValue("UpdateBy", client.UpdateBy);
                sqlCommand.Parameters.AddWithValue("CreatedDate", client.CreatedDate);
                sqlCommand.Parameters.AddWithValue("UpdateDate", client.UpdateDate);

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

        public bool UpdateClient(Models.Client client)
        {
            bool isUpdate = false;

            using (SqlConnection sqlConnection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(StoreProcedure.UPDATECLIENT, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (var clients in client.GetType().GetProperties())
                {
                    string name = clients.Name;
                    var value = clients.GetValue(client, null);
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientId" + name, value));
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

        public bool DeleteClient(Models.Client client)
        {
            bool isDelete = false;
            long ClientId = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETECLIENT);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientID", ClientId));

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
