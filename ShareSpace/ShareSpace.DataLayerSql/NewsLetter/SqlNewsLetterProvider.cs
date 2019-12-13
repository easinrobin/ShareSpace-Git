using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.NewsLetter;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Client;
using ShareSpace.Models.NewsLetter;
using ShareSpace.Utility;
namespace ShareSpace.DataLayerSql.NewsLetter
{
    public class SqlNewsLetterProvider
    {
        #region GetNewsLetter

        public List<Models.NewsLetter.NewsLetter> GetAllNewsLetters()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLNEWSLETTERS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.NewsLetter.NewsLetter> newsletterList = new List<Models.NewsLetter.NewsLetter>();
                    newsletterList = UtilityManager.DataReaderMapToList<Models.NewsLetter.NewsLetter>(dataReader);
                    return newsletterList;
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


        public Models.NewsLetter.NewsLetter GetNewsletterById(long newsletterId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETNEWSLETTERBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NewsLetterId", newsletterId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.NewsLetter.NewsLetter newsletter = new Models.NewsLetter.NewsLetter();
                    newsletter = UtilityManager.DataReaderMap<Models.NewsLetter.NewsLetter>(reader);
                    return newsletter;
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



        #endregion

        #region SetNewsLetter

        public long InsertNewsLetter(Models.NewsLetter.NewsLetter newsletter)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTNEWSLETTER, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "NewsLetterId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var newsletters in newsletter.GetType().GetProperties())
                {
                    if (newsletters.Name != "NewsLetterId")
                    {
                        string name = newsletters.Name;
                        var value = newsletters.GetValue(newsletter, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@NewsLetterId"].Value;
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

        public bool UpdateNewsLetter(Models.NewsLetter.NewsLetter newsletter)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATENEWSLETTER, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var newsletters in newsletter.GetType().GetProperties())
                {
                    string name = newsletters.Name;
                    var value = newsletters.GetValue(newsletter, null);
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

        public bool DeleteNewsLetter(long newsletterId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETENEWSLETTER, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NewsLetterId", newsletterId));

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
