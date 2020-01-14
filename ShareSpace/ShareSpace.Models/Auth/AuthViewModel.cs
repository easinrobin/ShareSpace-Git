using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Auth
{
    public class AuthViewModel
    {
        public Login Login { get; set; }
        public Vendor.Vendor VendorLogin { get; set; }
        public User.User UserLogin { get; set; }
    }
}
