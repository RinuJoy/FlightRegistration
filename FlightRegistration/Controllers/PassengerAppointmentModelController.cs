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
    public class PassengerAppointmentModelController : Controller
    {
        DataContext _DataContext;
        public PassengerAppointmentModelController(DataContext DataContext)
        {
            _DataContext = DataContext;
        }

        [HttpGet]
        public List<PassengerAppointmentViewModel> GetAll()
        {
            var output = (from passengerAppointmentModel in _DataContext.PassengerAppointmentModel 
                          join passengerModel in _DataContext.PassengerModel on passengerAppointmentModel.PassengerModelId equals passengerModel.PassengerModelId
                          join appointmentModel in _DataContext.AppointmentModel on passengerAppointmentModel.AppointmentModelId equals appointmentModel.AppointmentModelId
                          select new PassengerAppointmentViewModel
                          {
                              FirstName = passengerAppointmentModel.PassengerModel.FirstName,
                              LastName = passengerAppointmentModel.PassengerModel.LastName,
                              Weight = passengerAppointmentModel.PassengerModel.Weight,
                              Status = passengerAppointmentModel.PassengerModel.Status,
                              AppointmentDate = appointmentModel.AppointmentDate,
                              Capacity = appointmentModel.Capacity,
                              IsConfirmed = passengerAppointmentModel.IsConfirmed
                          }).ToList();
            return output;
        }

        [HttpGet("GetPending")]
        public List<PassengerAppointmentViewModel> Get()
        {
            var output = (from passengerAppointmentModel in _DataContext.PassengerAppointmentModel
                          join passengerModel in _DataContext.PassengerModel on passengerAppointmentModel.PassengerModelId equals passengerModel.PassengerModelId
                          join appointmentModel in _DataContext.AppointmentModel on passengerAppointmentModel.AppointmentModelId equals appointmentModel.AppointmentModelId
                          where passengerAppointmentModel.IsConfirmed == false
                          select new PassengerAppointmentViewModel
                          {
                              FirstName = passengerAppointmentModel.PassengerModel.FirstName,
                              LastName = passengerAppointmentModel.PassengerModel.LastName,
                              Weight = passengerAppointmentModel.PassengerModel.Weight,
                              Status = passengerAppointmentModel.PassengerModel.Status,
                              AppointmentDate = appointmentModel.AppointmentDate,
                              Capacity = appointmentModel.Capacity,
                              IsConfirmed = passengerAppointmentModel.IsConfirmed,
                              PassengerAppointmentModelId = passengerAppointmentModel.PassengerAppointmentModelId
                          }).ToList();
            return output;
        }

        [HttpGet("GetById/{id}")]
        public List<PassengerAppointmentViewModel> GetById(int id)
        {
            var output = (from passengerAppointmentModel in _DataContext.PassengerAppointmentModel
                          join passengerModel in _DataContext.PassengerModel on passengerAppointmentModel.PassengerModelId equals passengerModel.PassengerModelId
                          join appointmentModel in _DataContext.AppointmentModel on passengerAppointmentModel.AppointmentModelId equals appointmentModel.AppointmentModelId
                          where passengerModel.UserId == id
                          select new PassengerAppointmentViewModel
                          {
                              FirstName = passengerAppointmentModel.PassengerModel.FirstName,
                              LastName = passengerAppointmentModel.PassengerModel.LastName,
                              Weight = passengerAppointmentModel.PassengerModel.Weight,
                              Status = passengerAppointmentModel.PassengerModel.Status,
                              AppointmentDate = appointmentModel.AppointmentDate,
                              Capacity = appointmentModel.Capacity,
                              IsConfirmed = passengerAppointmentModel.IsConfirmed
                          }).ToList();
            return output;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] PassengerAppointmentModel passengerAppointmentModel)
        {
            try
            {
                var output = (from passengerAppointmentMdl in _DataContext.PassengerAppointmentModel
                              where passengerAppointmentMdl.AppointmentModelId == passengerAppointmentModel.AppointmentModelId
                              select passengerAppointmentMdl).Count();

                var appointmentMdl = (from appointmentModel in _DataContext.AppointmentModel
                                where appointmentModel.AppointmentModelId == passengerAppointmentModel.AppointmentModelId
                                select appointmentModel).FirstOrDefault();
                if (output < appointmentMdl.Capacity)
                {
                    passengerAppointmentModel.PassengerAppointmentModelId = 0;
                    passengerAppointmentModel.IsConfirmed = false;
                    _DataContext.Add(passengerAppointmentModel);
                    _DataContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public bool Put([FromBody] int passengerAppointmentModelId)
        {
            try
            {
                var PassengerAppointmentModel = (from passengerAppointmentModel in _DataContext.PassengerAppointmentModel
                              where passengerAppointmentModel.PassengerAppointmentModelId == passengerAppointmentModelId
                              select passengerAppointmentModel).FirstOrDefault();

                var PassengerModel = (from passengerModel in _DataContext.PassengerModel
                                                 where passengerModel.PassengerModelId == PassengerAppointmentModel.PassengerModelId
                                      select passengerModel).FirstOrDefault();

                PassengerAppointmentModel.IsConfirmed = true;
                PassengerModel.Status = 2;
                _DataContext.Update(PassengerAppointmentModel);
                _DataContext.Update(PassengerModel);
                _DataContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
