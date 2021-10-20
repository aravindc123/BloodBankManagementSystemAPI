using BloodBankDataAccessLayer;
using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankBusinessLayer
{
    public class BloodBankBusiness
    {
        BloodBankData bloodBankData = new BloodBankData();

        public List<EventRegistrationDetails> GetRegisteredUsers(int eventId)
        {
            return bloodBankData.GetRegisteredUsers(eventId);
        }
        public BloodStock GetBloodStock(int BloodBankId)
        {
            return bloodBankData.GetBloodStock(BloodBankId); 
        }
        public bool UpdateBloodStock(BloodStock bloodStock1, int StockId)
        {
            return bloodBankData.UpdateBloodStock(bloodStock1, StockId);
        }

        public List<BloodBankEvents> GetAllEvents(int bloodBankId)
        {
            return bloodBankData.GetAllEvents(bloodBankId);
        }
        public bool InsertCamp(Events events)
        {
            return bloodBankData.InsertCamp(events);
        }
        public bool MarkDonated(EventRegister eventRegister)
        {
            return bloodBankData.MarkDonated(eventRegister);
        }
        public bool DeleteCamp(int EventId)
        {
            return bloodBankData.DeleteCamp(EventId);
        }
    }
}
