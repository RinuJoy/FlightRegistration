using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Models
{
    public class UserDetailViewModel
    {
        public int UserTypeID { get; set; }
        public int UserId { get; set; }
        public string UserTypeName { get; set; }
        public string Username { get; set; }
    }
}
