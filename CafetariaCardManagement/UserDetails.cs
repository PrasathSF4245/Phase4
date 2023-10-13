using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        private static int s_id = 1000;
        private string _userId;
        public string UserID
        {
            get
            {
                return _userId;
            }
        }
        public string WorkStationNumber { get; set; }
        private double _balance;
        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        }
        public UserDetails(string name, string fatherName, long mobile, string mailId, Gender gender, string workStationNumber, double walletBalance)
        : base(name, fatherName, gender, mobile, mailId)
        {
            s_id++;
            _userId = "SF" + s_id;
            WorkStationNumber=workStationNumber;
            _balance = walletBalance;
           
        }
        public void WalletRecharge(double amount)
        {
            _balance += amount;
        }
        public void DeductAmount(double amount)
        {
            _balance -= amount;
        }

        public UserDetails(string user)
        {
            string[ ]userDetails=user.Split(",");
            s_id=int.Parse(userDetails[0].Remove(0,2));
            _userId=userDetails[0];
             Name = userDetails[1];
            FatherName = userDetails[2];
             Mobile =long .Parse(userDetails[3]);
            MailID = userDetails[4];
            Gender =Enum.Parse<Gender>( userDetails[5]);
             WorkStationNumber = userDetails[6];
             _balance = double.Parse(userDetails[7]);
           
        }
    }

}