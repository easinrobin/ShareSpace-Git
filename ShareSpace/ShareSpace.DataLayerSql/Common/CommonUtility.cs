using System.Configuration;

namespace ShareSpace.DataLayerSql.Common
{
    public static class CommonUtility
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
    }

    public static class StoreProcedure
    {
        //Clients
        public static string GETALLCLIENT = "sp_client_getallclients";

        public static string GETCLIENTBYID = "sp_client_getclientbyid";

        public static string INSERTCLIENT = "sp_client_insertclients";

        public static string UPDATECLIENT = "sp_client_updateclients";

        public static string DELETECLIENT = "sp_client_deleteclients";

        public static string GETCLIENTBYEMAIL = "sp_client_getclientbyemail";

        public static string Get_Client_By_Email_And_Password = "sp_client_GetClientByEmailAndPassword";

        //Properties
        public static string GETFEATUREDPROPERTIES = "sp_view_featureproperties";

        public static string GETSHARETYPE = "sp_property_getsharetype";

        public static string GETSHARETYPEFROMVIEW = "sp_view_getsharetype";

        public static string GETALLPROPERTYFROMVIEW = "sp_view_getallproperties";

        public static string GETPROPERTYDETAILSBYID = "sp_view_getpropertydetailsbyid";

        public static string GETCLIENTPROPERTYRATING = "sp_view_clientpropertyrating";

        public static string GETALLPROPERTYS = "sp_property_getproperty";

        public static string GETPROPERTYSBYID = "sp_property_getpropertybyid";

        public static string INSERTPROPERTYS = "sp_property_insertproperty";

        public static string UPDATEPROPERTYS = "sp_property_updateproperty";

        public static string DELETEPROPERTYS = "sp_property_deleteproperty";

        public static string Get_Property_PropertyRating = "sp_property_getPropertyAndPropertyRating";

        //Services
        public static string GETFEATUREDSERVICE = "sp_service_getfeaturedservices";

        public static string GETPROPERTYSERVICEONCLIENT= "sp_view_getPropertyServiceOnUI";
        public static string PROPERTY_PROPERTYSERVICE_GETBYPROPERTYIDS = "sp_property_propertyService_getByPropertyIds";
        //Booking
        public static string INSERTBOOKINGS = "sp_booking_insertbooking";

        public static string UPDATEBOOKINGS = "sp_booking_updatebooking";

        public static string GETALLBOOKINGS = "sp_booking_getallbooking";

        public static string GETBOOKINGSBYID = "sp_Booking_getBookingbyid";

        public static string DELETEBOOKINGS = "sp_booking_deletebooking";

        public static string GETCLIENTSBOOKINGHISTORY = "sp_view_getClientBookingHistory";

        //Vendor
        public static string GETALLVENDORS = "sp_vendor_getallvendors";

        public static string GETVENDORSBYID = "sp_vendor_getvendorbyid";

        public static string INSERTVENDORS = "sp_vendor_insertvendors";

        public static string UPDATEVENDORS = "sp_vendor_updatevendors";

        public static string DELETEVENDORS = "sp_vendor_deletevendors";

        public static string GETALLVENDORSBYEMAIL_MOBILE = "sp_vendor_getallvendorbyemailandmobile";

        //Transactions
        public static string GETALLTRANSACTIONS = "sp_transaction_getalltransaction";

        public static string GETTRANSACTIONSBYID = "sp_transaction_gettransactionbyid";

        public static string INSERTTRANSACTIONS = "sp_transaction_inserttransaction";

        public static string UPDATETRANSACTIONS = "sp_transaction_updatetransaction";

        public static string DELETETRANSACTIONS = "sp_transaction_deletetransaction";
    }
}
