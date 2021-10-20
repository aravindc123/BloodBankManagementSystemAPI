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
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        AdminBusiness adminBusiness = new AdminBusiness(); 

        [HttpGet]
        [Route("GetDonorDetails")]
        public List<DonorDetails> GetDonorDetails()
        {
            return adminBusiness.GetDonors();
        }

        [HttpGet]
        [Route("GetBloodBankDetails")]
        public List<UserBloodStock> GetBloodBanks()
        {
            return adminBusiness.GetBloodBanks(); 
        }

        [HttpDelete]
        [Route("DeleteDonor/{id}")]
        public bool DeleteDonor(int id)
        {
            return adminBusiness.DeleteDonor(id);
        }

        [HttpDelete]
        [Route("DeleteBloodBank/{Id}")]
        public bool DeleteBloodBank(int id)
        {
            return adminBusiness.DeleteBloodBank(id); 
        }

        [HttpGet]
        [Route("GetNotifications")]
        public List<Notification> GetNotifications()
        {
            return adminBusiness.GetNotifications(); 
        }

        [HttpDelete]
        [Route("DeleteNotifications/{id}")]
        public bool DeleteNotificatioms(int id)
        {
            return adminBusiness.DeleteNotifications(id); 
        }

        [HttpPost]
        [Route("InsertNotifications")]
        public bool InsertNotifications(Notification notification)
        {
            return adminBusiness.InsertNotifications(notification);
        }
    }
}
