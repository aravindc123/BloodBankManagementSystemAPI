using BloodBankBusinessLayer;
using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodBankManagementSystem.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [Route("RegisterDonor")]
        public bool RegisterDonor(Donor donor)
        {
            AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
            return authenticationBusiness.DonorRegister(donor);
       
        }

        [HttpPost]
        [Route("RegisterBloodBank")]
        public bool RegisterBloodBank(BloodBank bloodBank)
        {
            AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
           return authenticationBusiness.BloodBankRegister(bloodBank);
           
        }

        [HttpPost]
        [Route("login")]
        
        public IHttpActionResult DonorLogin(UserDetails userDetails)
        {
            AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
            Donor donor = authenticationBusiness.LoginDonor(userDetails);
            if ( donor == null)
            {
                return Ok(false);
            }
            else
            {
                return Ok(donor);
            }
           

        }

        [HttpPost]
        [Route("LoginBloodBank")]
        public IHttpActionResult BloodBankLogin(UserDetails userDetails)
        {
            AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
            BloodBank bloodBank = authenticationBusiness.LoginBloodBank(userDetails); 
            if(bloodBank == null)
            {
                return Ok(false);
            }
            else
            {
                return Ok(bloodBank);
            }
        }

        [HttpPost]
        [Route("LoginAdmin")]
       
        public bool AdminLogin(UserDetails userDetails)
        {
            AuthenticationBusiness authenticationBusiness = new AuthenticationBusiness();
            return authenticationBusiness.LoginAdmin(userDetails);
        }

    }
}
