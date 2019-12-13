using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpace.DataLayerSql.User;
using ShareSpace.Models.User;


namespace ShareSpace.BusinessLayer
{
    public class UserManager
    {
        #region Get
        public static List<User> GetAllUsers()
        {
            SqlUserProvider sqlUserProvider = new SqlUserProvider();
            var allUsers = sqlUserProvider.GetAllUsers();
            return allUsers;


        }

        public static User GetUserById(long userId)
        {
            SqlUserProvider sqlUserProvider = new SqlUserProvider();
            return sqlUserProvider.GetUserById(userId);
        }



        #endregion


        #region Set
        public static long InsertUser(User user)
        {
            SqlUserProvider sqlUserProvider = new SqlUserProvider();
            var id = sqlUserProvider.InsertUser(user);
            return id;
        }

        public static bool UpdateUser(User user)
        {
            SqlUserProvider sqlUserProvider = new SqlUserProvider();
            var isUpdate = sqlUserProvider.UpdateUser(user);
            return isUpdate;
        }

        public static bool DeleteUser(long userID)
        {
            SqlUserProvider sqlUserProvider = new SqlUserProvider();
            var isDelete = sqlUserProvider.DeleteUser(userID);
            return isDelete;
        }

        #endregion

    }
}