using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Transaction
{
    public class SqlTransactionProvider
    {
        #region Transaction
        public long InsertTransaction(Models.Transaction.Transaction transaction)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTTRANSACTIONS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "TransactionId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var transactions in transaction.GetType().GetProperties())
                {
                    if (transactions.Name != "TransactionId")
                    {
                        string name = transactions.Name;
                        var value = transactions.GetValue(transaction, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@TransactionId"].Value;
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

        public bool UpdateTransaction(Models.Transaction.Transaction transaction)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATETRANSACTIONS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var transactions in transaction.GetType().GetProperties())
                {
                    string name = transactions.Name;
                    var value = transactions.GetValue(transaction, null);
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

        public List<Models.Transaction.Transaction> GetAllTransactions()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLTRANSACTIONS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Transaction.Transaction> transactionList = new List<Models.Transaction.Transaction>();
                    transactionList = UtilityManager.DataReaderMapToList<Models.Transaction.Transaction>(dataReader);
                    return transactionList;
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

        public Models.Transaction.Transaction GetTransactionById(long transactionId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETTRANSACTIONSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TransactionId", transactionId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Transaction.Transaction transaction = new Models.Transaction.Transaction();
                    transaction = UtilityManager.DataReaderMap<Models.Transaction.Transaction>(reader);
                    return transaction;
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



        public bool DeleteTransaction(long transactionId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETETRANSACTIONS, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TransactionID", transactionId));

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
