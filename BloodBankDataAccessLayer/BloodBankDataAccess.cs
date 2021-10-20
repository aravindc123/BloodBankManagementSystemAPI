using BloodBankEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankDataAccessLayer
{
    public class BloodBankDataAccess
    {
        BBMSDBEntities db = new BBMSDBEntities();

       public BloodStocks GetBloodStocks(int bloodBankId)
        {
            tbBloodStock blood = db.tbBloodStocks.Find(bloodBankId);

            BloodStocks bloodStock = new BloodStocks()
            {
                StockId = blood.StockId,
                AB_Count = blood.AB_Count,
      
            };
            return bloodStock;
        }
    }
}
