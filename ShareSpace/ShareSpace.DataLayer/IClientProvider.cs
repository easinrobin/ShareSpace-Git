using System.Collections.Generic;

namespace ShareSpace.DataLayer.Client
{
    public interface IClientProvider
    {
        List<Models.Client> GetAllClients();
    }
}