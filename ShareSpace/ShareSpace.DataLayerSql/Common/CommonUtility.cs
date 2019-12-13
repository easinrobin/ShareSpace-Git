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

        public static string Get_Admin_PropertyList = "sp_view_adminPanelPropertyList";

        public static string Get_Admin_PropertyListById = "sp_property_getAdminPropertyById";

        public static string GETPROPERTYSBYID = "sp_property_getpropertybyid";

        public static string INSERTPROPERTYS = "sp_property_insertproperty";

        public static string UPDATEPROPERTYS = "sp_property_updateproperty";

        public static string Update_Admin_PropertyList = "sp_property_view_updateAdminPropertyList";

        public static string DELETEPROPERTYS = "sp_property_deleteproperty";

        public static string Hide_Property = "sp_property_hideProperty";

        public static string Get_Property_PropertyRating = "sp_property_getPropertyAndPropertyRating";

        public static string GET_PROPERTY_BY_SEARCH = "sp_property_getPropertyBySearch";
        public static string GET_PROPERTY_BY_PROPERTYID_BOOKINGID = "sp_property_getPropertyByPropertyIdnBookingId";

        //Services
        public static string GETFEATUREDSERVICE = "sp_service_getfeaturedservices";

        public static string GETPROPERTYSERVICEONCLIENT= "sp_view_getPropertyServiceOnUI";

        public static string PROPERTY_PROPERTYSERVICE_GETBYPROPERTYIDS = "sp_property_propertyService_getByPropertyIds";

        public static string Insert_Property_Service = "sp_propertyservice_insertpropertyservice";

        public static string Get_All_Services = "sp_service_getallservice";
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

        //Address
        public static string GETALLADDRESSS = "sp_propertyaddress_getallpropertyaddress";

        public static string GETADDRESSSBYID = "sp_propertyaddress_getpropertyaddressbyid";

        public static string GETADDRESSSBYPROPERTYID = "sp_propertyaddress_getpropertyaddressbypropertyid";

        public static string INSERTADDRESSS = "sp_propertyaddress_insertpropertyaddress";

        public static string UPDATEADDRESSS = "sp_propertyaddress_updatepropertyaddress";

        public static string DELETEADDRESSS = "sp_propertyaddress_deletepropertyaddress";

        //Gallery
        public static string GETALLGALLERYS = "sp_gallery_getallgallery";

        public static string GETGALLERYSBYID = "sp_gallery_getgallerybyid";

        public static string Get_Gallery_By_PropertyId = "sp_gallery_getgallerybypropertyid";

        public static string INSERTGALLERYS = "sp_gallery_insertgallery";

        public static string UPDATEGALLERYS = "sp_gallery_updategallery";

        public static string DELETEGALLERYS = "sp_gallery_deletegallery";

        //Users
        public static string GETALLUSERS = "sp_user_getallusers";

        public static string GETUSERBYID = "sp_user_getuserbyid";

        public static string INSERTUSER = "sp_user_insertuser";

        public static string UPDATEUSER = "sp_user_updateuser";

        public static string DELETEUSER = "sp_user_deleteuser";

        //Testimonial

        public static string GETALLTESTIMONIALS = "sp_testimonial_getalltestimonials";

        public static string GETTESTIMONIALBYID = "sp_testimonial_gettestimonialbyid";

        public static string INSERTTESTIMONIAL = "sp_testimonial_inserttestimonial";

        public static string UPDATETESTIMONIAL = "sp_testimonial_updatetestimonial";

        public static string DELETETESTIMONIAL = "sp_testimonial_deletetestimonial";

        //NewsLetter

        public static string GETALLNEWSLETTERS = "sp_newsletter_getallnewsletters";

        public static string GETNEWSLETTERBYID = "sp_newsletter_getnewsletterbyid";

        public static string INSERTNEWSLETTER = "sp_newsletter_insertnewsletter";

        public static string UPDATENEWSLETTER = "sp_newsletter_updatenewsletter";

        public static string DELETENEWSLETTER = "sp_newsletter_deletenewsletter";
    }
}
