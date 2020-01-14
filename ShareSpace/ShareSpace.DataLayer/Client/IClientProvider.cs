using System.Collections.Generic;

namespace ShareSpace.DataLayer.Client
{
    public interface IClientProvider
    {
        List<Models.Client.Client> GetAllClients();
        long InsertClient(Models.Client.Client client);
        bool UpdateClient(Models.Client.Client client);
        bool DeleteClient(long clientId);
        Models.Client.Client GetClientById(long clientId);
        Models.Client.Client GetClientByEmail(string email);
    }
}
