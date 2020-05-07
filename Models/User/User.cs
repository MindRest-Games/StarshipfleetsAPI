using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarshipfleetsAPI.Models.User
{
    public class User
    {
        public int? UserID { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool? Premium { get; set; }
        public DateTime? PremiumExpires { get; set; }
        public DateTime? LastLogin { get; set; }
        public string IPAddress { get; set; }
    }
}
