using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.DataLayer.Transaction
{
    public interface ITransactionProvider
    {
        List<Models.Transaction.Transaction> GetAllTransactions();
    }
}
