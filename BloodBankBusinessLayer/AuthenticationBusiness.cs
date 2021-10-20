using BloodBankDataAccessLayer;
using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankBusinessLayer
{
    public class AuthenticationBusiness
    {
        public bool DonorRegister(Donor donor)
        {
            Authentication authentication = new Authentication();
            return authentication.DonorRegister(donor); 
        }
        public bool BloodBankRegister(BloodBank bloodBank)
        {
            Authentication authentication = new Authentication();
            return authentication.BloodBankRegister(bloodBank);
        }

        public Donor LoginDonor(UserDetails userDetails)
        {
            Authentication authentication = new Authentication();
            return authentication.LoginDonor(userDetails);
        }

        public BloodBank LoginBloodBank(UserDetails userDetails)
        {
            Authentication authentication = new Authentication();
            return authentication.LoginBloodBank(userDetails);
        }

        public bool LoginAdmin(UserDetails userDetails)
        {
            Authentication authentication = new Authentication();
            return authentication.LoginAdmin(userDetails);
        }
    }
}
