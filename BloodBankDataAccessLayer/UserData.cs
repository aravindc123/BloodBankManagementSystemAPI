using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDataAccessLayer
{
    public class UserData
    {
        BBMSDBEntities db = new BBMSDBEntities();
        public List<BloodBankEvents> GetAllEvents()
        {
            var data = (from bloodbank in db.spGetEventsByBloodBank()
                        select new BloodBankEvents()
                        {
                           BloodBankId = bloodbank.BloodBankId,
                           BloodBankName = bloodbank.BloodBankName,
                           City = bloodbank.City,
                           EventDate = bloodbank.EventDate,
                           EventName = bloodbank.EventName,
                           EventClosing = bloodbank.EventClosing,
                           EventId = bloodbank.EventId,
                           EventTime = bloodbank.EventTime
                        }).ToList();
            return data;
        }
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

        public List<History> GetHistory(int userId)
        {
            var data = (from datas in db.tbHistories
                        where datas.UserId == userId
                        select new History() {
                            BloodTransactionId = datas.BloodTransactionId,
                            DonationDate = datas.DonationDate,
                            UserId  = datas.UserId
                        }).ToList();
            return data;
        }

        public List<UserBloodStock> GetBloodStockByBloodBank()
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
        public bool RegisterForEvent(EventRegister eventRegister)
        {
            var data = (from donor in db.tbEventRegistrations
                        where donor.EventId == eventRegister.EventId && donor.UserId == eventRegister.UserId
                        select donor).FirstOrDefault();
            if ( data == null)
            {
                try
                {
                    tbEventRegistration tbEventRegistration = new tbEventRegistration()
                    {
                        RegId = eventRegister.RegId,
                        EventId = eventRegister.EventId,
                        UserId = eventRegister.UserId,
                        IsDonated = eventRegister.IsDonated
                    };
                    db.tbEventRegistrations.Add(tbEventRegistration);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
