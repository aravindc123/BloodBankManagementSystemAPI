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
    [RoutePrefix("api/BloodBank")]
    public class BloodBankController : ApiController
    {
        BloodBankBusiness bloodBankBusiness = new BloodBankBusiness(); 

        [HttpGet]
        [Route("GetEventRegisteredUsers/{BloodBankId}")]
        public List<EventRegistrationDetails> GetRegisteredDonor(int BloodBankId)
        {
            return bloodBankBusiness.GetRegisteredUsers(BloodBankId);
        }
        [HttpGet]
        [Route("GetBloodStock/{BloodBankId}")]
        public BloodStock GetBloodStock(int BloodBankId)
        {
            return bloodBankBusiness.GetBloodStock(BloodBankId);
        }

        [HttpPut]
        [Route("UpdateBloodStocks/{StockId}")]
        public bool UpdateBloodStock(BloodStock bloodStock1, int StockId)
        {
            return bloodBankBusiness.UpdateBloodStock(bloodStock1, StockId); 
        }

        [HttpPut]
        [Route("MarkDonated")]
        public bool MarkDonorDonated(EventRegister eventRegister)
        {
            return bloodBankBusiness.MarkDonated(eventRegister);
        }

        [HttpPost]
        [Route("InsertCamp")]
        public bool InsertCamp(Events events){
            return bloodBankBusiness.InsertCamp(events);
        }

        [HttpGet]
        [Route("GetAllEvents/{bloodBankId}")]
        public List<BloodBankEvents> GetAllEvents(int bloodBankId)
        {
            return bloodBankBusiness.GetAllEvents(bloodBankId);
        }
        [HttpDelete]
        [Route("DeleteEvent/{EventId}")]
        public bool DeleteCamp(int EventId)
        {
            return bloodBankBusiness.DeleteCamp(EventId);
        }
        
    }
}
