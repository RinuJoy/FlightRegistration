using FlightRegistration.DBContext;
using FlightRegistration.EncryptionLib;
using FlightRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FlightRegistration.Controllers
{
    [Route("api/[controller]")]
    public class UserRegistrationController : Controller
    {
        DataContext _DatabaseContext;
        public UserRegistrationController(DataContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }

        [HttpGet("userName/{userName}")]
        public UserDetails GetByName( string userName)
        {
                var output = (from userDetail in _DatabaseContext.UserDetails
                              where userDetail.Username == userName
                              select userDetail).FirstOrDefault();                
                 return output;
        }


        // POST api/values
        [HttpPost]
        public int Post([FromBody] UserDetails userDetails)
        {
            try
            {

                var output = (from userDetail in _DatabaseContext.UserDetails
                              where userDetail.Username == userDetails.Username
                              select userDetail.Username).Count();

                if (output > 0)
                {
                    return 0;
                }
                else
                {
                    var userTypeID = (from user in _DatabaseContext.UserType
                                      where user.UserTypeName == "User"
                                      select user.UserTypeID).SingleOrDefault();
                    userDetails.UserId = 0;
                    userDetails.UserTypeID = userTypeID;
                    userDetails.Password = EncryptionLibrary.EncryptText(userDetails.Password);
                    userDetails.CreatedOn = DateTime.Now;
                    _DatabaseContext.Add(userDetails);
                    _DatabaseContext.SaveChanges();

                    return userDetails.UserId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
