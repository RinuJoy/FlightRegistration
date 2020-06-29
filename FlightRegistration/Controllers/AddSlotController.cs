using FlightRegistration.DBContext;
using FlightRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Controllers
{
    [Route("api/[controller]")]
    public class AddSlotController : Controller
    {
        DataContext _DataContext;
        public AddSlotController(DataContext DataContext)
        {
            _DataContext = DataContext;
        }

        [HttpGet]
        public List<AppointmentModel> Get()
        {
            var output = (from appointmentModel in _DataContext.AppointmentModel                         
                          select appointmentModel).ToList();
            return output;
        }

        [HttpPost]
        public bool Post([FromBody] AppointmentModel appointmentModel)
        {
            try
            {

                var output = (from AppointmentModel in _DataContext.AppointmentModel
                              where AppointmentModel.AppointmentDate == appointmentModel.AppointmentDate
                              select AppointmentModel.AppointmentModelId).Count();

                if (output > 0)
                {
                    return false;
                }
                else
                {
                    appointmentModel.AppointmentModelId = 0;
                    _DataContext.Add(appointmentModel);
                    _DataContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
