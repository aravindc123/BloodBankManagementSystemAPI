using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDataAccessLayer
{
    public class AdminDataAccess
    {
        BBMSDBEntities db = new BBMSDBEntities();
        public List<DonorDetails> GetDonorDetails()
        {
            var donors = (from User in db.tbUsers
                          select new DonorDetails()
                          {
                              UserId = User.UserId,
                              UserName = User.UserName,
                              AadharNumber = User.AadharNumber,
                              BloodGroup = User.BloodGroup,
                              DOB = User.DOB,
                              IsDonor = User.IsDonor,
                              City = User.City,
                              Contact = User.Contact,
                              HealthCondition = User.HealthCondition
                          }).ToList();
            return donors; 
        }

        public List<BloodBankDetails> GetBloodBankDetails()
        {
            var bloodbank = (from blood in db.tbBloodBanks
                          select new BloodBankDetails()
                          {
                              BloodBankId = blood.BloodBankId,
                              BloodBankName = blood.BloodBankName,
                              Contact = blood.Contact,
                              City = blood.City
                          }).ToList();
            return bloodbank;
        }

        public bool DeleteDonor(int donorId)
        {
            try
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
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteBloodBank(int bloodbank)
        {
            try
            {
                tbBloodBank blood = db.tbBloodBanks.Find(bloodbank);
                if (blood != null)
                {
                    db.tbBloodBanks.Remove(blood);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool InsertNotification(Notification notification)
        {
            try
            {
                tbNotification notify = new tbNotification() { 
                    NotificationId = notification.NotificationId,  
                    Content = notification.Content,
                    Title = notification.Title
                };
                db.tbNotifications.Add(notify);
                db.SaveChanges();
                return true; 
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Notification> GetNotification()
        {
            List<Notification> notification = new List<Notification>(); 
            try
            {
                var notifications = (from notify in db.tbNotifications
                                     select new Notification() {
                                        NotificationId = notify.NotificationId,
                                        Content = notify.Content,
                                        Title = notify.Title
                                     }).ToList();
                return notifications;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return notification;
            }
        }

        public bool DeleteNotification(int notificationId)
        {
            try
            {
                tbNotification notify = db.tbNotifications.Find(notificationId);
                if(notify == null)
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
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
