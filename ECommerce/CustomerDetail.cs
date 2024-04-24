using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    public class CustomerDetail
    {
        private static int _custId=1000;
        string userName;
        string city;
        long phoneNumber;
        public double walletBalance;
        string mailId;
        public string customerId;
        public CustomerDetail(string name, string city, long phoneNumber, double walBal,string mailId)
        {
            this.userName = name;
            this.city = city;
            this.phoneNumber = phoneNumber;
            this.walletBalance = walBal;
            this.mailId = mailId;
            customerId = "CID"+(++_custId);
        }
        public void WalletRecharge(double amount)
        {
            walletBalance+=amount;
        }
        public void DeductBalance(double amount)
        {
            walletBalance-=amount;
        }
    }
}