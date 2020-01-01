using System;

namespace ShareSpace.Models.Property
{ 
    public class ClientPropertyRating
    {
        public int PropertyId { get; set; } 
        public int ClientId { get; set; }
        public int PropertyRatingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClientPhoto { get; set; }
        public string Email { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
