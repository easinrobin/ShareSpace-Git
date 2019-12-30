using System.Collections.Generic;
using ShareSpace.DataLayerSql.Client;
using ShareSpace.Models.Auth;
using ShareSpace.Models.Client;

namespace ShareSpace.BusinessLayer
{
    public class ClientManager
    {
        #region Get
        public static List<Client> GetAllClients()
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

        public static Client GetClientByEmail(string email)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            return sqlClientProvider.GetClientByEmail(email);
        }

        public static Client GetClientByEmailAndPassword(string email, string password)
        {
            SqlClientProvider clientProvider = new SqlClientProvider();
            return clientProvider.GetClientByEmailAndPassword(email, password);
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

        public static bool HideClient(long clientId)
        {
            SqlClientProvider sqlClientProvider = new SqlClientProvider();
            var isDelete = sqlClientProvider.HideClient(clientId);
            return isDelete;
        }
        #endregion
    }
}
