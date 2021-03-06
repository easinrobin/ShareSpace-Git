﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.Booking;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Booking;
using ShareSpace.Models.Client;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Booking
{
    public class SqlBookingProvider : IBookingProvider
    {
        #region SetBooking
        public long InsertBooking(Models.Booking.Booking booking)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTBOOKINGS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "BookingId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var bookings in booking.GetType().GetProperties())
                {
                    if (bookings.Name != "BookingId")
                    {
                        string name = bookings.Name;
                        var value = bookings.GetValue(booking, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@BookingId"].Value;
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

        public bool UpdateBooking(Models.Booking.Booking booking)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATEBOOKINGS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var bookings in booking.GetType().GetProperties())
                {
                    string name = bookings.Name;
                    var value = bookings.GetValue(booking, null);
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
        
        public bool DeleteBooking(long bookingId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEBOOKINGS, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BookingID", bookingId));

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

        #region GetBooking

        public List<Models.Booking.Booking> GetAllBookings()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLBOOKINGS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Booking.Booking> bookingList = new List<Models.Booking.Booking>();
                    bookingList = UtilityManager.DataReaderMapToList<Models.Booking.Booking>(dataReader);
                    return bookingList;
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

        public List<AdminBookingList> GetAdminBookingList()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Admin_BookingList, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<AdminBookingList> bookingList = new List<AdminBookingList>();
                    bookingList = UtilityManager.DataReaderMapToList<AdminBookingList>(dataReader);
                    return bookingList;
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

        public Models.Booking.Booking GetBookingById(long bookingId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETBOOKINGSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@BookingId", bookingId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Booking.Booking booking = new Models.Booking.Booking();
                    booking = UtilityManager.DataReaderMap<Models.Booking.Booking>(reader);
                    return booking;
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

        public List<ClientsBookingHistory> GetClientBookingHistory(long clientId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETCLIENTSBOOKINGHISTORY, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ClientId", +clientId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<ClientsBookingHistory> bookingList = new List<ClientsBookingHistory>();
                    bookingList = UtilityManager.DataReaderMapToList<ClientsBookingHistory>(reader);
                    return bookingList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion
    }
}
