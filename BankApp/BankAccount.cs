using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp
{
    enum Gender{Male,Female};
        public class BankAccount
    {
        private static int _custNo=1000;
        public string CustId;
        string Name;
        public double Balance;
        Gender Gender;
        long Phone;
        string Mail;
        DateTime dob;


        public BankAccount()
        {
            Console.Write("Enter your Customer Name: ");
            this.Name = Console.ReadLine();
            Console.Write("Enter your Balance: ");
            this.Balance = double.Parse(Console.ReadLine());
            Console.Write("Enter your Gender: ");
            this.Gender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Phone number: ");
            this.Phone = long.Parse(Console.ReadLine());
            Console.Write("Enter your Mail ID: ");
            this.Mail = Console.ReadLine();
            Console.Write("Enter your Date of Birth (dd/MM/yyyy): ");
            this.dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            CustId = "HDFC"+(_custNo++);
            Console.WriteLine("Your customer ID is : "+ CustId);

        }
        public double Withdraw()
        {
            Console.WriteLine("Enter amount to Withdraw: ");
            double withdraw = double.Parse(Console.ReadLine());
            if (withdraw <= Balance)
                Balance -= withdraw;
            else
                Console.WriteLine("Insufficient Balance");

            return Balance;
        }
        public double Deposit()
        {
            Console.WriteLine("Enter amount to add: ");
            Balance += double.Parse(Console.ReadLine());

            return Balance;
        }

        public void Print(){
            Console.WriteLine("Welcome "+ Name+"!");
            Console.WriteLine("Your Info: ");
            Console.WriteLine("your CustomerID: "+CustId);
            Console.WriteLine("your Gender: "+ Gender);
            Console.WriteLine("your Balance: "+Balance);
        }
        
    }
}