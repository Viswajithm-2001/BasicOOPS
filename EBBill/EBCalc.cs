using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class EBCalc
    {
        static private int _meterId=1001;
        static private int _billId = 1001;
        public string userName;
        long phoneNumber;
        string mailId;
        public string mID;
        public string bId;
        public double units;
        public EBCalc(){}
        public EBCalc(string userName, long phoneNumber,string mailId)
        {
            double units =0;
            this.units = units;
            this.userName=userName;
            this.phoneNumber=phoneNumber;
            this.mailId=mailId;
            mID="EB"+(_meterId++);

        }

        public void Display(){
            Console.WriteLine("Here are your Info");
            Console.WriteLine("your Meter ID : "+mID);
            Console.WriteLine("Your Phone number: "+phoneNumber);
            Console.WriteLine("Units used: "+units);
        }
        
        public static double Calculator(){
            Console.Write("Enter your unit :");
            double input = double.Parse(Console.ReadLine());
            return input*5;
        }
        public void CalcDisplay(){
            bId="Bill"+(_billId++);
        }
    }
}