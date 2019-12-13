using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.Testimonial;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Client;
using ShareSpace.Models.Testimonial;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Testimonial
{
    public class SqlTestimonialProvider : ITestimonialProvider
    {
        #region GetTestimonial

        public List<Models.Testimonial.Testimonial> GetAllTestimonials()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLTESTIMONIALS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Testimonial.Testimonial> testimonialList = new List<Models.Testimonial.Testimonial>();
                    testimonialList = UtilityManager.DataReaderMapToList<Models.Testimonial.Testimonial>(dataReader);
                    return testimonialList;
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


        public Models.Testimonial.Testimonial GetTestimonialById(long testimonialId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETTESTIMONIALBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TestimonialId", testimonialId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Testimonial.Testimonial testimonial = new Models.Testimonial.Testimonial();
                    testimonial = UtilityManager.DataReaderMap<Models.Testimonial.Testimonial>(reader);
                    return testimonial;
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

        #region SetTestimonial

        public long InsertTestimonial(Models.Testimonial.Testimonial testimonial)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTTESTIMONIAL, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "TestimonialId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var testimonials in testimonial.GetType().GetProperties())
                {
                    if (testimonials.Name != "TestimonialId")
                    {
                        string name = testimonials.Name;
                        var value = testimonials.GetValue(testimonial, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@TestimonialId"].Value;
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

        public bool UpdateTestimonial(Models.Testimonial.Testimonial testimonial)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATETESTIMONIAL, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var testimonials in testimonial.GetType().GetProperties())
                {
                    string name = testimonials.Name;
                    var value = testimonials.GetValue(testimonial, null);
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

        public bool DeleteTestimonial(long testimonialId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETETESTIMONIAL, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@TestimonialId", testimonialId));

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
