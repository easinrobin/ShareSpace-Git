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
        

        public static string GETALLCLIENT = "sp_client_getallclients";

        public static string GETCLIENTBYID = "sp_client_getclientbyid";

        public static string INSERTCLIENT = "sp_client_insertclients";

        public static string UPDATECLIENT = "sp_client_updateclients";

        public static string DELETECLIENT = "sp_client_deleteclients";


        
        public static string GETALLVENDORS = "sp_vendor_getallvendors";

        public static string GETVENDORSBYID = "sp_vendor_getvendorbyid";

        public static string INSERTVENDORS = "sp_vendor_insertvendors";

        public static string UPDATEVENDORS = "sp_vendor_updatevendors";

        public static string DELETEVENDORS = "sp_vendor_deletevendors";

        public static string GETVENDORBYID { get; internal set; }
    }
}
