using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Models
{
    public class PassengerAppointmentModel
    {
        [Key]
        public int PassengerAppointmentModelId { get; set; }
        [ForeignKey("PassengerModel")]
        public int PassengerModelId { get; set; }
        [ForeignKey("AppointmentModel")]
        public int AppointmentModelId { get; set; }
        public bool IsConfirmed { get; set; }
        public PassengerModel PassengerModel { get; set; }
        public AppointmentModel AppointmentModel { get; set; }
    }
}
