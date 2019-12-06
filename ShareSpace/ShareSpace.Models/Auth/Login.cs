using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpace.Models.Auth
{
    public class Login
    {
        public long ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string MobileNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Password { get; set; }
        public string ClientPhoto { get; set; }
    }
}
