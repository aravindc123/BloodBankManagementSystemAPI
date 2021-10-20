using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDataAccessLayer
{
    public class BloodBankData
    {
        BBMSDBEntities db = new BBMSDBEntities();
        public BloodStock GetBloodStock(int BloodBankId)
        {
            var BloodStock = (from stock in db.tbBloodStocks
                              where stock.BloodBankId == BloodBankId
                              select new BloodStock()
                              {
                                  StockId = stock.StockId,
                                  BloodBankId = stock.BloodBankId,
                                  APositive = stock.APositive,
                                  BPositive = stock.BPositive,
                                  OPositive = stock.OPositive,
                                  ABPositive = stock.ABPositive,
                                  ANegative = stock.ANegative,
                                  BNegative = stock.BNegative,
                                  ONegative = stock.ONegative,
                                  ABNegative = stock.ABNegative
                              }
            ).FirstOrDefault();

            return BloodStock;
        }

        public List<BloodBankEvents> GetAllEvents(int bloodBankId)
        {
            var data = (from bloodbank in db.spGetEventsByBloodBank()
                        where bloodbank.BloodBankId == bloodBankId
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

        public bool UpdateBloodStock(BloodStock bloodStock1, int StockId)
        {
            if (db.tbBloodStocks.Find(StockId) != null)
            {
                try
                {
                    tbBloodStock tbBloodStock = db.tbBloodStocks.Find(StockId);
                    tbBloodStock.StockId = bloodStock1.StockId;
                    tbBloodStock.BloodBankId = bloodStock1.BloodBankId;
                    tbBloodStock.APositive = bloodStock1.APositive;
                    tbBloodStock.BPositive = bloodStock1.BPositive;
                    tbBloodStock.OPositive = bloodStock1.OPositive;
                    tbBloodStock.ABPositive = bloodStock1.ABPositive;
                    tbBloodStock.ANegative = bloodStock1.ANegative;
                    tbBloodStock.BNegative = bloodStock1.BNegative;
                    tbBloodStock.ONegative = bloodStock1.ONegative;
                    tbBloodStock.ABNegative = bloodStock1.ABNegative;
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

        public bool InsertCamp(Events events)
        {
            tbEvent tbEvent = new tbEvent()
            {
                EventId = events.EventId,
                City = events.City,
                BloodBankId = events.BloodBankId,
                EventName = events.EventName,
                EventDate = events.EventDate,
                EventClosing = events.EventClosing,
                EventTime = events.EventTime
            };
            try
            {
                db.tbEvents.Add(tbEvent);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<EventRegistrationDetails> GetRegisteredUsers(int eventId)
        {
            var data = db.tbEvents.Find(eventId); 
            var registeredUsers = db.GetRegisterDetails(eventId).ToList();
            var Users = (from item in registeredUsers
                         select new EventRegistrationDetails()
                         {
                             RegId = item.RegId,
                             UserName = item.UserName,
                             AadharNumber = item.AadharNumber,
                             Contact = item.Contact,
                             UserId = item.UserId,
                             EventName = item.EventName,
                             IsDonated = item.IsDonated,
                         }).ToList();
            return Users;    
        }

        public bool MarkDonated(EventRegister eventRegister)
        {
            var data = db.tbEventRegistrations.Find(eventRegister.RegId); 
            if(data != null)
            {
                data.RegId = eventRegister.RegId;
                data.EventId = eventRegister.EventId;
                data.UserId = eventRegister.UserId;
                data.IsDonated = 1;
                db.SaveChanges();
                return true; 
            }
            else
            {
                return false;
            }

        }
        public bool DeleteCamp(int EventId)
        {
            tbEvent tb = db.tbEvents.Find(EventId);
            if (tb != null)
            {
                db.tbEvents.Remove(tb);
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
