﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShareSpace.DataLayer.Property;
using ShareSpace.DataLayerSql.Common;
using ShareSpace.Models.Booking;
using ShareSpace.Models.Client;
using ShareSpace.Models.Property;
using ShareSpace.Utility;

namespace ShareSpace.DataLayerSql.Property
{
    public class SqlPropertyProvider : IPropertyProvider
    {
        #region GetProperty

        public List<FeatureProperty> GetFeatureProperties(int maxRow)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETFEATUREDPROPERTIES, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NumberOfProperty", maxRow));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<FeatureProperty> featurePropertiesList = new List<FeatureProperty>();
                    featurePropertiesList = UtilityManager.DataReaderMapToList<FeatureProperty>(reader);
                    return featurePropertiesList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<PropertySearchResultNew> GetShareType(string type)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETSHARETYPEFROMVIEW, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ShareType", type));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertySearchResultNew> shareTypeList = new List<PropertySearchResultNew>();
                    shareTypeList = UtilityManager.DataReaderMapToList<PropertySearchResultNew>(reader);
                    return shareTypeList;
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

        public List<Models.Property.Property> GetAllProperties()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Models.Property.Property> propertyList = new List<Models.Property.Property>();
                    propertyList = UtilityManager.DataReaderMapToList<Models.Property.Property>(dataReader);
                    return propertyList;
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

        public List<AdminPropertyList> GetAdminPropertyList()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Admin_PropertyList, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<AdminPropertyList> propertyList = new List<AdminPropertyList>();
                    propertyList = UtilityManager.DataReaderMapToList<AdminPropertyList>(dataReader);
                    return propertyList;
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

        public List<AdminPropertyList> GetPendingPropertyList()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Pending_PropertyList, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<AdminPropertyList> propertyList = new List<AdminPropertyList>();
                    propertyList = UtilityManager.DataReaderMapToList<AdminPropertyList>(dataReader);
                    return propertyList;
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

        public List<PropertySearchResultNew> GetPropertiesAndPropertyRating()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Property_PropertyRating, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<PropertySearchResultNew> propertyList = new List<PropertySearchResultNew>();
                    propertyList = UtilityManager.DataReaderMapToList<PropertySearchResultNew>(dataReader);
                    return propertyList;
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

        public List<PropertySearchResult> GetAllPropertySearchResults()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETALLPROPERTYFROMVIEW, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertySearchResult> propertyList = new List<PropertySearchResult>();
                    propertyList = UtilityManager.DataReaderMapToList<PropertySearchResult>(reader);

                    return propertyList;
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

        public PropertyDetails GetPropertyDetailsById(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETPROPERTYDETAILSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    PropertyDetails propertyDetails = new PropertyDetails();
                    propertyDetails = UtilityManager.DataReaderMap<PropertyDetails>(reader);
                    return propertyDetails;
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

        public PropertyView GetPropertyViewById(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETPROPERTYDETAILSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    PropertyView propertyDetails = new PropertyView();
                    propertyDetails = UtilityManager.DataReaderMap<PropertyView>(reader);
                    return propertyDetails;
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

        public List<ClientPropertyRating> GetClientPropertyRatings(int Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETCLIENTPROPERTYRATING, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<ClientPropertyRating> ratingList = new List<ClientPropertyRating>();
                    ratingList = UtilityManager.DataReaderMapToList<ClientPropertyRating>(reader);
                    return ratingList;
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

        public Models.Property.Property GetPropertyById(long propertyId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETPROPERTYSBYID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", propertyId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Models.Property.Property property = new Models.Property.Property();
                    property = UtilityManager.DataReaderMap<Models.Property.Property>(reader);
                    return property;
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

        public AdminPropertyList GetAdminPropertyListById(long propertyId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Admin_PropertyListById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", propertyId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    AdminPropertyList property = new AdminPropertyList();
                    property = UtilityManager.DataReaderMap<AdminPropertyList>(reader);
                    return property;
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

        public List<PropertyServiceViewModel> GetPropertyServicesOnClient(long propertyId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GETPROPERTYSERVICEONCLIENT, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", propertyId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertyServiceViewModel> propertyServiceList = new List<PropertyServiceViewModel>();
                    propertyServiceList = UtilityManager.DataReaderMapToList<PropertyServiceViewModel>(reader);
                    return propertyServiceList;
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

        public List<PropertyServiceViewModel> GetPropertyServiceByPropertyIds(string ids)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.PROPERTY_PROPERTYSERVICE_GETBYPROPERTYIDS, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyIds", ids));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertyServiceViewModel> propertyServiceList = new List<PropertyServiceViewModel>();
                    propertyServiceList = UtilityManager.DataReaderMapToList<PropertyServiceViewModel>(reader);
                    return propertyServiceList;
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

        public PropertyWorkingDays GetPropertyWorkingDaysByPropertyId(long Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GET_PROPERTY_WORKING_DAYS_BY_PROPERTY_ID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    PropertyWorkingDays workingDaysList = new PropertyWorkingDays();
                    workingDaysList = UtilityManager.DataReaderMap<PropertyWorkingDays>(reader);
                    return workingDaysList;
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

        public List<PropertyWorkingDays> GetAllPropertyWorkingDays()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GET_ALL_PROPERTY_WORKING_DAYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<PropertyWorkingDays> workingDaysList = new List<PropertyWorkingDays>();
                    workingDaysList = UtilityManager.DataReaderMapToList<PropertyWorkingDays>(dataReader);
                    return workingDaysList;
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

        #region SetProperty

        public long InsertProperty(Models.Property.Property property)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERTPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "PropertyId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var propertys in property.GetType().GetProperties())
                {
                    if (propertys.Name != "PropertyId")
                    {
                        string name = propertys.Name;
                        var value = propertys.GetValue(property, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@PropertyId"].Value;
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

        public long InsertPropertyWorkingDays(PropertyWorkingDays workingDays)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERT_PROPERTY_WORKING_DAYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var propertys in workingDays.GetType().GetProperties())
                {
                    if (propertys.Name != "Id")
                    {
                        string name = propertys.Name;
                        var value = propertys.GetValue(workingDays, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@Id"].Value;
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

        public bool UpdateProperty(Models.Property.Property property)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATEPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var propertys in property.GetType().GetProperties())
                {
                    string name = propertys.Name;
                    var value = propertys.GetValue(property, null);
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

        public bool UpdatePropertyWorkingDays(PropertyWorkingDays workingDays)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UPDATE_PROPERTY_WORKING_DAYS, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var propertys in workingDays.GetType().GetProperties())
                {
                    string name = propertys.Name;
                    var value = propertys.GetValue(workingDays, null);
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

        public bool DeleteProperty(long propertyId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETEPROPERTYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyID", propertyId));

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

        public bool DeletePropertyWorkingDays(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DELETE_PROPERTY_WORKING_DAYS, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

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

        public bool HideProperty(long propertyId)
        {
            bool isHidden = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Hide_Property, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyID", propertyId));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isHidden = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isHidden;
        }

        public bool ApproveProperty(long propertyId)
        {
            bool isApproved = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Approve_Property, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyID", propertyId));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isApproved = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isApproved;
        }

        public bool HidePropertyByVendorId(long vendorId)
        {
            bool isHidden = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Hide_Property_By_VendorId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@VendorId", vendorId));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isHidden = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isHidden;
        }

        public long InsertPropertyService(PropertyService propertyService)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Insert_Property_Service, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "PropertyServiceId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var service in propertyService.GetType().GetProperties())
                {
                    if (service.Name != "PropertyServiceId")
                    {
                        string name = service.Name;
                        var value = service.GetValue(propertyService, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@PropertyServiceId"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public long InsertPropertyRating(PropertyRating propertyRating)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.INSERT_PROPERTY_RATING, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "PropertyRatingId", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var service in propertyRating.GetType().GetProperties())
                {
                    if (service.Name != "PropertyRatingId")
                    {
                        string name = service.Name;
                        var value = service.GetValue(propertyRating, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@PropertyRatingId"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool DeletePropertyServiceById(long propertyServiceId)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Delete_PropertyService_byId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyServiceId", propertyServiceId));

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
        //public List<PropertySearchResultNew> GetPropertiesBySearch(string fromDate, string toDate, string fromHour, string toHour)
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(StoreProcedure.GET_PROPERTY_BY_SEARCH, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
        //        command.Parameters.Add(new SqlParameter("@toDate", toDate));
        //        command.Parameters.Add(new SqlParameter("@fromHour", fromHour));
        //        command.Parameters.Add(new SqlParameter("@toHour", toHour));
        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader dataReader = command.ExecuteReader();
        //            List<PropertySearchResultNew> propertyList = new List<PropertySearchResultNew>();
        //            propertyList = UtilityManager.DataReaderMapToList<PropertySearchResultNew>(dataReader);
        //            return propertyList;
        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception("Exception retrieving reviews. " + e.Message);
        //        }

        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}

        public List<PropertySearchResultNew> GetPropertiesBySearch(string searchtext)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GET_PROPERTY_BY_SEARCH, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@searchtext", searchtext));
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<PropertySearchResultNew> propertyList = new List<PropertySearchResultNew>();
                    propertyList = UtilityManager.DataReaderMapToList<PropertySearchResultNew>(dataReader);
                    return propertyList;
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

        public BookingConfirmed GetPropertyViewByPropertyIdnBookingId(long propertyId, long bookingId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GET_PROPERTY_BY_PROPERTYID_BOOKINGID, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@propertyId", propertyId));
                command.Parameters.Add(new SqlParameter("@bookingId", bookingId));
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    BookingConfirmed propertyList = new BookingConfirmed();
                    propertyList = UtilityManager.DataReaderMap<BookingConfirmed>(dataReader);
                    return propertyList;
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

        public List<PropertyServiceViewModel> GetServicesByPropertyId(long propertyId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.Get_Services_By_PropertyId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PropertyId", propertyId));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<PropertyServiceViewModel> serviceList = new List<PropertyServiceViewModel>();
                    serviceList = UtilityManager.DataReaderMapToList<PropertyServiceViewModel>(reader);
                    return serviceList;
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
    }
}
