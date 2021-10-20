using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankEntityLayer
{
    public class Donor
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long Contact { get; set; }
        public long AadharNumber { get; set; }
        public string BloodGroup { get; set; }
        public System.DateTime DOB { get; set; }
        public string City { get; set; }
        public string HealthCondition { get; set; }
        public int IsDonor { get; set; }


    }

    public class BloodBank
    {
        public int BloodBankId { get; set; }
        public string BloodBankName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public long Contact { get; set; }
    }

    public class UserDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class BloodBankDetails
    {
        public int BloodBankId { get; set; }
        public string BloodBankName { get; set; }
        public string City { get; set; }
        public long Contact { get; set; }
    }

    public class DonorDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public long Contact { get; set; }
        public long AadharNumber { get; set; }
        public string BloodGroup { get; set; }
        public System.DateTime DOB { get; set; }
        public string City { get; set; }
        public string HealthCondition { get; set; }
        public int IsDonor { get; set; }
    }

    public class Notification
    {
        public int NotificationId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }

    public class BloodStock
    {
        public int StockId { get; set; }
        public int BloodBankId { get; set; }
        public int APositive { get; set; }
        public int BPositive { get; set; }
        public int OPositive { get; set; }
        public int ABPositive { get; set; }
        public int ANegative { get; set; }
        public int BNegative { get; set; }
        public int ONegative { get; set; }
        public int ABNegative { get; set; }
    }

    public class Events
    {
        public int EventId { get; set; }
        public int BloodBankId { get; set; }
        public string EventName { get; set; }
        public System.DateTime EventDate { get; set; }
        public System.DateTime EventTime { get; set; }
        public System.DateTime EventClosing { get; set; }
        public string City { get; set; }
    }

    public class EventRegistrationDetails
    {
        public int RegId { get; set; }
        public string UserName { get; set; }
        public long AadharNumber { get; set; }
        public long Contact { get; set; }
        public int UserId { get; set; }
        public int IsDonated { get; set; }
        public string EventName { get; set; }
    }

    public class BloodBankEvents
    {
        public int BloodBankId { get; set; }
        public string BloodBankName { get; set; }
        public string City { get; set; }
        public System.DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public System.DateTime EventClosing { get; set; }
        public System.DateTime EventTime { get; set; }
        public int EventId { get; set; }
    }

    public class History
    {
        public int BloodTransactionId { get; set; }
        public int UserId { get; set; }
        public System.DateTime DonationDate { get; set; }
    }

    public class UserBloodStock
    {
        public string BloodBankName { get; set; }
        public string City { get; set; }
        public long Contact { get; set; }
        public int ABNegative { get; set; }
        public int ABPositive { get; set; }
        public int ANegative { get; set; }
        public int APositive { get; set; }
        public int BNegative { get; set; }
        public int BPositive { get; set; }
        public int ONegative { get; set; }
        public int OPositive { get; set; }
        public int StockId { get; set; }
        public int BloodBankId { get; set; }
    }

    public class EventRegister
    {
        public int RegId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int IsDonated { get; set; }
    }


}
