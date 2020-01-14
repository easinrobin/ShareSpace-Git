using System.Collections.Generic;
using System.Web.Mvc;
using ShareSpace.BusinessLayer;
using ShareSpace.Models.User;

namespace AdminPanel.Controllers
{
    


    public class UserController : Controller
    {
        // GET: User
        public ActionResult InsertUser()
        {
            return View();
        }



        public ActionResult AdminUsers()
        {
            List<User> allUsers = UserManager.GetAllUsers();
            return View("~/Views/User/AdminUsers.cshtml", allUsers);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUser(User user)
        {      

            UserManager manager = new UserManager();
            if (user != null && user.UserID > 0)
            {
                UserManager.UpdateUser(user);
            }
            else
            {
                UserManager.InsertUser(user);
            }


            return RedirectToAction("AdminUsers");
        }

        public ActionResult UpdateUser(int userID)
        {
            User user = UserManager.GetUserById(userID);
            return View("~/Views/User/InsertUser.cshtml", user);
        }

        public ActionResult DeleteUser(long userID)
        {
            UserManager.DeleteUser(userID);
            return RedirectToAction("AdminUsers");
        }
    }
}