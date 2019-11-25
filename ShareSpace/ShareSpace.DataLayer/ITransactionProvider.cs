using System.Collections.Generic;

namespace ShareSpace.DataLayer.Transaction
{
    public interface ITransactionProvider
    {
        List<Models.Transaction> GetAllTransactions();
    }
}