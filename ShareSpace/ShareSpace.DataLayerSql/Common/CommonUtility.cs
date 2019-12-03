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

        //Properties
        public static string GETFEATUREDPROPERTIES = "sp_view_featureproperties";

        public static string GETSHARETYPE = "sp_property_getsharetype";

        public static string GETSHARETYPEFROMVIEW = "sp_view_getsharetype";

        public static string GETALLPROPERTYFROMVIEW = "sp_view_getallproperties";

        public static string GETPROPERTYDETAILSBYID = "sp_view_getpropertydetailsbyid";

        public static string GETCLIENTPROPERTYRATING = "sp_view_clientpropertyrating";
        
        //Services
        public static string GETFEATUREDSERVICE = "sp_service_getfeaturedservices";

        //Booking
        public static string INSERTBOOKINGS = "sp_booking_insertbooking";

        public static string UPDATEBOOKINGS = "sp_booking_updatebooking";

        public static string GETALLBOOKINGS = "sp_booking_getallbooking";

        public static string GETBOOKINGSBYID = "sp_Booking_getBookingbyid";

        public static string DELETEBOOKINGS = "sp_booking_deletebooking";

        public static string GETCLIENTSBOOKINGHISTORY = "sp_view_getClientBookingHistory";
    }
}
