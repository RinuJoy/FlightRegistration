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
    public class ValidateUsernameController : Controller
    {

        DataContext _DataContext;
        public ValidateUsernameController(DataContext DataContext)
        {
            _DataContext = DataContext;
        }


        // POST api/values
        [HttpPost]
        public bool Post([FromBody]UserDetails userDetails)
       {
            try
            {
                if (string.IsNullOrEmpty(userDetails.Username))
                {
                    return false;
                }

                var output = (from userDetail in _DataContext.UserDetails
                              where userDetail.Username == userDetails.Username
                              select userDetail.Username).Count();

                if (output > 0)
                {
                    return false;
                }
                else
                {
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
