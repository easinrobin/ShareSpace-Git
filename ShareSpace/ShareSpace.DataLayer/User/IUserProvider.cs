using System.Collections.Generic;
using ShareSpace.Models.User;

namespace ShareSpace.DataLayer.User
{
    public interface IUserProvider
    {
        List<Models.User.User> GetAllUsers();
        long InsertUser(Models.User.User user);
        bool UpdateUser(Models.User.User user);
        Models.User.User GetUserById(long userID);
        bool DeleteUser(long userID);
        
    }
}
