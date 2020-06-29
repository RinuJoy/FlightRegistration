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
    public class PassengerModelController : Controller
    {
        DataContext _DataContext;
        public PassengerModelController(DataContext DataContext)
        {
            _DataContext = DataContext;
        }

        [HttpGet("GetById/{id}")]
        public PassengerModel GetById(int id)
        {
            var output = (from passengerModel in _DataContext.PassengerModel
                          where passengerModel.UserId == id 
                          select passengerModel).FirstOrDefault();
            return output;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] PassengerModel passengerModel)
        {
            try
            {
                passengerModel.PassengerModelId = 0;
                passengerModel.Status = 1;
                _DataContext.Add(passengerModel);
                _DataContext.SaveChanges();

                return true;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public bool Put([FromBody] PassengerModel passengerModel)
        {
            try
            {
                passengerModel.Status = 2;
                _DataContext.Update(passengerModel);
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
