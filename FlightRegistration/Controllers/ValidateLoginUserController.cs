using FlightRegistration.DBContext;
using FlightRegistration.EncryptionLib;
using FlightRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightRegistration.Controllers
{
    [Route("api/[controller]")]
    public class ValidateLoginUserController : Controller
    {
        private readonly IOptions<MyConfigReader> config;
        DataContext _DatabaseContext;
        public ValidateLoginUserController(DataContext databasecontext, IOptions<MyConfigReader> config)
        {
            this.config = config;
            _DatabaseContext = databasecontext;
        }


        // POST api/values
        [HttpPost]
        public LoginResponse Post([FromBody]UserDetails UserDetail)
        {
            try
            {
                LoginResponse loginresponse = new LoginResponse();

                if (string.IsNullOrEmpty(UserDetail.Username) || string.IsNullOrEmpty(UserDetail.Password))
                {
                    loginresponse.Username = string.Empty;
                    loginresponse.Token = string.Empty;
                    loginresponse.UserTypeID = 0;
                    return loginresponse;
                }

                var encryptedPassword = (from user in _DatabaseContext.UserDetails
                                         where user.Username == UserDetail.Username
                                         select user.Password).SingleOrDefault();


                if (!string.IsNullOrEmpty(encryptedPassword))
                {

                    if (EncryptionLibrary.DecryptText(encryptedPassword) == UserDetail.Password)
                    {
                        string Encryptpassword = EncryptionLibrary.EncryptText(UserDetail.Password);

                        var isUserExists = (from user in _DatabaseContext.UserDetails
                                            where user.Username == UserDetail.Username && user.Password == Encryptpassword
                                            select user).Count();

                        if (isUserExists > 0)
                        {
                            var userDetails = (from user in _DatabaseContext.UserDetails
                                                join usertype in _DatabaseContext.UserType on user.UserTypeID equals usertype.UserTypeID
                                                where user.Username == UserDetail.Username && user.Password == Encryptpassword
                                                select new UserDetailViewModel
                                                {
                                                    UserId = user.UserId,
                                                    UserTypeID = user.UserTypeID,
                                                    UserTypeName = usertype.UserTypeName,
                                                    Username = user.Username
                                                }).SingleOrDefault();

                            if (userDetails != null)
                            {
                                GenerateToken(userDetails, loginresponse);
                            }

                            return loginresponse;
                        }
                        else
                        {
                            loginresponse.Username = string.Empty;
                            loginresponse.Token = string.Empty;
                            loginresponse.UserTypeID = 0;
                            return loginresponse;
                        }
                    }
                }

                loginresponse.Username = string.Empty;
                loginresponse.Token = string.Empty;
                loginresponse.UserTypeID = 0;
                return loginresponse;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public void GenerateToken(UserDetailViewModel UserDetails, LoginResponse loginresponse)
        {

            try
            {
                var isAlreadyTokenExists = (from tokenmanager in _DatabaseContext.TokenManager
                                            where tokenmanager.UserID == UserDetails.UserId
                                            select tokenmanager).Count();

                if (isAlreadyTokenExists > 0)
                {
                    var deleteToken = (from temptoken in _DatabaseContext.TokenManager
                                       where temptoken.UserID == UserDetails.UserId
                                       select temptoken).SingleOrDefault();

                    _DatabaseContext.TokenManager.Remove(deleteToken);
                    _DatabaseContext.SaveChanges();
                }

                var IssuedOn = DateTime.Now;
                var newToken = KeyGenerator.GenerateToken(UserDetails);

                TokenManager token = new TokenManager();
                token.TokenID = 0;
                token.TokenKey = newToken;
                token.IssuedOn = IssuedOn;
                token.ExpiresOn = DateTime.Now.AddMinutes(Convert.ToInt32(this.config.Value.TokenExpiry));
                token.CreatedOn = DateTime.Now;
                token.UserID = UserDetails.UserId;
                var result = _DatabaseContext.TokenManager.Add(token);

                _DatabaseContext.SaveChanges();
                loginresponse.Username = UserDetails.Username;
                loginresponse.Token = newToken;
                loginresponse.UserTypeID = UserDetails.UserTypeID;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

