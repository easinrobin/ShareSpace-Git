using System.Collections;
using System.Collections.Generic;
using ShareSpace.DataLayerSql.Client;
using ShareSpace.Models;

namespace ShareSpace.BusinessLayer
{
    public class ClientManager
    {
        #region Get
        public static List<Client> GetAllClients(int i)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            var allClients = sqlClientProvider.GetAllClients();
            return allClients;
        }

        public static Client GetClientById(long clientId)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            return sqlClientProvider.GetClientById(clientId);
        }


        #endregion
        #region Set
        public static long InsertClient(Client client)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            var id = sqlClientProvider.InsertClient(client);
            return id;
        }

        public static bool UpdateClient(Client client)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            var isUpdate = sqlClientProvider.UpdateClient(client);
            return isUpdate;
        }

        public static bool DeleteClient(long clientId)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            var isDelete = sqlClientProvider.DeleteClient(clientId);
            return isDelete;
        }
        #endregion


    }
}