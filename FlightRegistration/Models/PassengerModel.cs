using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Models
{
    public class PassengerModel
    {
        [Key]
        public int PassengerModelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Weight { get; set; }
        public int Status { get; set; }
        [ForeignKey("UserDetails")]
        public int UserId { get; set; }

    }
}
