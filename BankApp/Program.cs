using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace BankApp;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Banking App!");
        List<BankAccount> CustInfo = new List<BankAccount>();

        int choice;
        do
        {
            Console.WriteLine("Select \n1 for Register \n2 for Login \n3 for exit");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 2:
                    {
                        Console.Write("Enter Your Customer Id: ");
                        string Cid = Console.ReadLine().Trim();
                        bool flag = false;
                        foreach (BankAccount bank in CustInfo)
                        {
                            if (bank.CustId == Cid)
                            {
                                int ch;
                                do
                                {
                                    bank.Print();
                                    Console.WriteLine("Enter 1 to withdraw \n2 to deposit\n3 to check Balance\n4 to exit ");
                                    ch = int.Parse(Console.ReadLine());
                                    if (ch == 2)
                                    {
                                        bank.Deposit();
                                        Console.WriteLine("Your Balance Now : " + bank.Balance);
                                    }
                                    else if (ch == 1)
                                    {
                                        bank.Withdraw();
                                        Console.WriteLine("Your Balance Now : " + bank.Balance);
                                    }
                                    else if (ch == 3)
                                    {
                                        Console.WriteLine("Your Balance Now : " + bank.Balance);
                                    }
                                } while (ch != 4);
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        if (!flag)
                            Console.WriteLine("Invalid User ID");

                        break;
                    }
                case 1:
                    {
                        BankAccount bank = new BankAccount();
                        CustInfo.Add(bank);
                        Console.WriteLine("your Info saved !");


                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Thank you!");
                        break;
                    }
            }


        } while (choice != 3);

    }
}