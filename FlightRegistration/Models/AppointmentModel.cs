using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Models
{
    public class AppointmentModel
    {
        [Key]
        public int AppointmentModelId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Capacity { get; set; }
       
    }
}
