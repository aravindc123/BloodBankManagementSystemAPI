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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        UserBusiness userBusiness = new UserBusiness();
        [HttpGet]
        [Route("GetEvents")]
        public List<BloodBankEvents> GetAllEvents()
        {
            return userBusiness.GetAllEvents();
        }

        [HttpGet]
        [Route("GetDonors")]
        public List<DonorDetails> GetAllDonors()
        {
            return userBusiness.GetDonors();
        }

        [HttpGet]
        [Route("GetHistory/{userId}")]
        public List<History> GetHistory(int userId)
        {
            return userBusiness.GetHistory(userId); 
        }

        [HttpGet]
        [Route("GetBloodStock")]
        public List<UserBloodStock> GetBloodStockByBloodBank()
        {
            return userBusiness.GetBloodStockByBloodBank();
        }
        [HttpPost]
        [Route("RegisterForEvent")]
        public bool RegisterForEvent(EventRegister eventRegister)
        {
            return userBusiness.RegisterForEvent(eventRegister);
        }
    }
}
