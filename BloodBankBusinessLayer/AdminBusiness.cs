using BloodBankDataAccessLayer;
using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankBusinessLayer
{
    public class AdminBusiness
    {
        AdminData adminData = new AdminData(); 
        public List<DonorDetails> GetDonors()
        {
            return adminData.GetDonors();
        }

        public List<UserBloodStock> GetBloodBanks()
        {
            return adminData.GetBloodBanks();
        }

        public bool DeleteDonor(int donorId)
        {
            return adminData.DeleteDonor(donorId);
        }

        public bool DeleteBloodBank(int bloodBankId)
        {
            return adminData.DeleteBloodBank(bloodBankId);
        }

        public List<Notification> GetNotifications()
        {
            return adminData.GetNotifications(); 
        }

        public bool InsertNotifications(Notification notification)
        {
            return adminData.InsertNotifications(notification);
        }

        public bool DeleteNotifications(int notificationId)
        {
            return adminData.DeleteNotifications(notificationId);
        }
    }
}
