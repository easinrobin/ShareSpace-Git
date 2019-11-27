using System.Collections;
using System.Collections.Generic;
using ShareSpace.DataLayerSql.Transaction;
using ShareSpace.Models;

namespace ShareSpace.BusinessLayer
{
    public class TransactionManager
    {
        #region Get
        public static List<Transaction> GetAllTransactions(int i)
        {
            SqlTransactionProvider sqlTransactionProvider = new SqlTransactionProvider();
            var allTransactions = sqlTransactionProvider.GetAllTransactions();
            return allTransactions;
        }

        public static Transaction GetTransactionById(long transactionId)
        {
            SqlTransactionProvider sqlTransactionProvider = new SqlTransactionProvider();
            return sqlTransactionProvider.GetTransactionById(transactionId);
        }

       
        #endregion
        #region Set
        public static long InsertTransaction(Transaction transaction)
        {
            SqlTransactionProvider sqlTransactionProvider = new SqlTransactionProvider();
            var id = sqlTransactionProvider.InsertTransaction(transaction);
            return id;
        }

        public static  bool UpdateTransaction(Transaction transaction)
        {
            SqlTransactionProvider sqlTransactionProvider = new SqlTransactionProvider();
            var isUpdate = sqlTransactionProvider.UpdateTransaction(transaction);
            return isUpdate;
        }

        public static bool DeleteTransaction(long transactionId)
        {
            SqlTransactionProvider sqlTransactionProvider = new SqlTransactionProvider();
            var isDelete = sqlTransactionProvider.DeleteTransaction(transactionId);
            return isDelete;
        }
        #endregion


    }
}
