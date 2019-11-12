using System.Collections;
using System.Collections.Generic;
using ShareSpace.DataLayerSql.Client;
using ShareSpace.Models;

namespace ShareSpace.BusinessLayer
{
    public static class ClientManager
    {
        public static SqlClientProvider sqlClientProvider = new SqlClientProvider();

        public static string InsertClient(Client client)
        {
            bool isSaved = sqlClientProvider.InsertClient(client);
            if (isSaved)
            {
                return "Saved Successful";
            }
            else
            {
                return "Failed";
            }
        }

        public static List<Client> GetAllClients()
        {
            return sqlClientProvider.GetAllClients();
        }

        public static List<Client> GetClientById(long ID)
        {
            return sqlClientProvider.GetClientById(ID);
        }

        public static string UpdateClient(Client client)
        {
            bool isUpdate = sqlClientProvider.UpdateClient(client);
            if (isUpdate)
            {
                return "Update successful";
            }
            else
            {
                return "failed";
            }
        }

        public static string DeleteClient(Client client)
        {
            bool isDeleted = sqlClientProvider.DeleteClient(client);
            if (isDeleted)
            {
                return "Deleted successfully";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
