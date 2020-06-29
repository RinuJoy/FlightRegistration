using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Models
{
    public class PassengerAppointmentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Weight { get; set; }
        public int Status { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Capacity { get; set; }
        public bool IsConfirmed { get; set; }
        public int PassengerAppointmentModelId { get; set; }
    }
}
