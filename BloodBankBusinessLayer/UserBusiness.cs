using BloodBankDataAccessLayer;
using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankBusinessLayer
{
    public class UserBusiness
    {
        UserData userData = new UserData();

        public List<BloodBankEvents> GetAllEvents()
        {
            return userData.GetAllEvents();
        }
        public List<DonorDetails> GetDonors()
        {
            return userData.GetDonors(); 
        }
        public List<History> GetHistory(int userId)
        {
            return userData.GetHistory(userId);
        }
        public List<UserBloodStock> GetBloodStockByBloodBank()
        {
            return userData.GetBloodStockByBloodBank();
        }
        public bool RegisterForEvent(EventRegister eventRegister)
        {
            return userData.RegisterForEvent(eventRegister);
        }
    }
}
