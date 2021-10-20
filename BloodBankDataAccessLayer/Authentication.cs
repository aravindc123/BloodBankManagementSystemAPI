using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDataAccessLayer
{
    public class Authentication
    {
        BBMSDBEntities db = new BBMSDBEntities();

        public bool DonorRegister(Donor donor)
        {
            if(!db.tbUsers.Where(d => d.AadharNumber == donor.AadharNumber && d.UserName == donor.UserName).Any())
            {
                try
                {
                    tbUser user = new tbUser()
                    {
                        UserId = donor.UserId,
                        UserName = donor.UserName,
                        Password = encryption(donor.Password),
                        AadharNumber = donor.AadharNumber,
                        BloodGroup = donor.BloodGroup,
                        DOB = donor.DOB,
                        IsDonor = donor.IsDonor,
                        City = donor.City,
                        Contact = donor.Contact,
                        HealthCondition = donor.HealthCondition
                    };
                    db.tbUsers.Add(user);
                    db.SaveChanges(); 
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool BloodBankRegister(BloodBank bloodBank)
        {
            if(db.tbBloodBanks.Find(bloodBank.BloodBankId) == null)
            {
                try
                {
                    tbBloodBank bloodBanks = new tbBloodBank()
                    {
                        BloodBankId = bloodBank.BloodBankId,
                        BloodBankName = bloodBank.BloodBankName,
                        Password = encryption(bloodBank.Password), 
                        City = bloodBank.City,
                        Contact = bloodBank.Contact
                    };
                    db.tbBloodBanks.Add(bloodBanks);
                    db.SaveChanges(); 
                    return true; 
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Donor LoginDonor(UserDetails userDetails)
        {
            Donor donor = new Donor();
            try
            {
                string encrypted = encryption(userDetails.Password);
                tbUser donors = db.tbUsers.FirstOrDefault(user => user.UserName == userDetails.UserName && user.Password == encrypted);
                if (donors != null)
                {
                    var user = (from User in db.tbUsers
                                where User.UserName == userDetails.UserName && User.Password == encrypted
                                select new Donor()
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
                                }).FirstOrDefault();
                    return user;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception e)
            {
                return donor;
            }
        }

        public BloodBank LoginBloodBank(UserDetails userDetails)
        {
            BloodBank bloodB = new BloodBank();
            try
            {
                string encrypted = encryption(userDetails.Password);

                var bloodBank = (from blood in db.tbBloodBanks
                                 where blood.BloodBankName == userDetails.UserName && blood.Password == encrypted
                                 select new BloodBank() {
                                 BloodBankId = blood.BloodBankId,
                                 BloodBankName = blood.BloodBankName,
                                 Contact = blood.Contact,
                                 City = blood.City
                                 }).FirstOrDefault();
                return bloodBank;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool LoginAdmin(UserDetails userDetails)
        {
            string encrypted = encryption(userDetails.Password);
            var admins = db.tbAdmins.FirstOrDefault(admin => admin.UserName == userDetails.UserName && admin.Password == userDetails.Password);
            if (admins == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
    }
}
