using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.DataLayerSql.Common
{
    public static class CommonUtility
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
    }

    public static class StoreProcedure
    {
        

        public static string GETALLCLIENTS = "sp_client_getallclients";

        public static string GETCLIENTBYID = "sp_client_getclientbyid";

        public static string INSERTCLIENTS = "sp_client_insertclients";

        public static string UPDATECLIENTS = "sp_client_updateclients";

        public static string DELETECLIENTS = "sp_client_deleteclients";


        
        public static string GETALLVENDORS = "sp_vendor_getallvendors";

        public static string GETVENDORSBYID = "sp_vendor_getvendorbyid";

        public static string INSERTVENDORS = "sp_vendor_insertvendors";

        public static string UPDATEVENDORS = "sp_vendor_updatevendors";

        public static string DELETEVENDORS = "sp_vendor_deletevendors";

        public static string GETALLVENDORSBYEMAIL_MOBILE = "sp_vendor_getallvendorbyemailandmobile";



        public static string GETALLPROPERTYS = "sp_property_getallproperty";

        public static string GETPROPERTYSBYID = "sp_property_getpropertybyid";

        public static string INSERTPROPERTYS = "sp_property_insertproperty";

        public static string UPDATEPROPERTYS = "sp_property_updateproperty";

        public static string DELETEPROPERTYS = "sp_property_deleteproperty";


        public static string GETALLBOOKINGS = "sp_booking_getallbooking";

        public static string GETBOOKINGSBYID = "sp_booking_getbookingbyid";

        public static string INSERTBOOKINGS = "sp_booking_insertbooking";

        public static string UPDATEBOOKINGS = "sp_booking_updatebooking";

        public static string DELETEBOOKINGS = "sp_booking_deletebooking";


        public static string GETALLTRANSACTIONS = "sp_transaction_getalltransaction";

        public static string GETTRANSACTIONSBYID = "sp_transaction_gettransactionbyid";

        public static string INSERTTRANSACTIONS = "sp_transaction_inserttransaction";

        public static string UPDATETRANSACTIONS = "sp_transaction_updatetransaction";

        public static string DELETETRANSACTIONS = "sp_transaction_deletetransaction";





    }
}
