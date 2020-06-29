using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Weight { get; set; }
        public string Contact_No { get; set; }
        public string Email { get; set; }
        public int UserTypeID { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
