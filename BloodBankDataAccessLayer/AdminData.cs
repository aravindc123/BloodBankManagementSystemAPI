using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDataAccessLayer
{
    public class AdminData
    {
        BBMSDBEntities db = new BBMSDBEntities();

        public List<DonorDetails> GetDonors()
        {
            var donors = (from donor in db.tbUsers
                          select new DonorDetails()
                          {
                              UserId = donor.UserId,
                              UserName = donor.UserName,
                              AadharNumber = donor.AadharNumber,
                              BloodGroup = donor.BloodGroup,
                              DOB = donor.DOB,
                              IsDonor = donor.IsDonor,
                              City = donor.City,
                              Contact = donor.Contact,
                              HealthCondition = donor.HealthCondition
                          }).ToList();
            return donors;
        }
        //public List<BloodBankDetails> GetBloodBanks()
        //{
        //    var bloodbanks = (from bloodBank in db.tbBloodBanks
        //                      select new BloodBankDetails()
        //                      {
        //                          BloodBankId = bloodBank.BloodBankId,
        //                          BloodBankName = bloodBank.BloodBankName,
        //                          City = bloodBank.City,
        //                          Contact = bloodBank.Contact
        //                      }).ToList();
        //    return bloodbanks;
        //}

        public List<UserBloodStock> GetBloodBanks()
        {
            var data = (from stocks in db.GetBloodBankStock()
                        select new UserBloodStock()
                        {
                            BloodBankName = stocks.BloodBankName,
                            Contact = stocks.Contact,
                            City = stocks.City,
                            StockId = stocks.StockId,
                            APositive = stocks.APositive,
                            BPositive = stocks.BPositive,
                            OPositive = stocks.OPositive,
                            ABPositive = stocks.ABPositive,
                            ANegative = stocks.ANegative,
                            BNegative = stocks.BNegative,
                            ABNegative = stocks.ABNegative,
                            ONegative = stocks.ONegative,
                            BloodBankId = stocks.BloodBankId
                        }).ToList();
            return data;
        }

        public bool DeleteDonor(int donorId)
        {
            tbUser user = db.tbUsers.Find(donorId); 
            if(user != null)
            {
                db.tbUsers.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false; 
            }
        }

        public bool DeleteBloodBank(int bloodBankId)
        {
            tbBloodBank user = db.tbBloodBanks.Find(bloodBankId);
            if (user != null)
            {
                db.tbBloodBanks.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Notification> GetNotifications()
        {
            var notifications = (from notify in db.tbNotifications
                                 select new Notification()
                                 {
                                     NotificationId = notify.NotificationId,
                                     Title = notify.Title, 
                                     Content = notify.Content
                                 }).ToList();
            return notifications;
        }

        public bool InsertNotifications(Notification notification)
        {
            tbNotification notify = new tbNotification()
            {
                NotificationId = notification.NotificationId,
                Content = notification.Content,
                Title = notification.Title
            };
            try
            {
                db.tbNotifications.Add(notify);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }

        public bool DeleteNotifications(int notificationId)
        {
            tbNotification notify = db.tbNotifications.Find(notificationId); 
            if(notify != null)
            {
                db.tbNotifications.Remove(notify);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
   