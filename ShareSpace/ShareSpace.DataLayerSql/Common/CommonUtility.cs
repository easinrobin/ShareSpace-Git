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

        public static string GETCLIENTBYEMAIL = "sp_client_getclientbyemail";
    }
}
