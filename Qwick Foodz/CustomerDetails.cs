using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
        /*Field: _balance
Properties: CustomerID, WalletBalance
Methods: WalletRecharge, DeductBalance
*/

        private double  _balance;
        private static int s_customerID=1000;
        public string CustomerID { get;}

public double WalletBalance { get{return _balance;}  }
        public CustomerDetails(string name,string fatherName,Gender gender,long mobile, DateTime dob, string mailID,string location ,double WalletBalance ):base( name, fatherName, gender, mobile,  dob,  mailID, location)
        {
            CustomerID="CID"+(++s_customerID);
            _balance=WalletBalance;
        }
        public CustomerDetails(string name,string fatherName,Gender gender,long mobile, DateTime dob, string mailID,string location  ):base( name, fatherName, gender, mobile,  dob,  mailID, location)
        {
            CustomerID="CID"+(++s_customerID);
          
        }

      

        public double WalletRecharge(double amoumnt)
        {
            return _balance+=amoumnt;
        }
        public double DeductBalance(double amoumnt)
        {
            return _balance-=amoumnt;
        }
    }
}