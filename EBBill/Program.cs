using System;
using System.Collections.Generic;
namespace EBBill;

class Program
{
    public static void Main(string[] args)
    {
        List<EBCalc> EbList = new List<EBCalc>();
        int choice;
        do
        {
            Console.WriteLine("Enter \n1. Registration\n2. Login\n3. Exit");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Registration Process");
                        Console.Write("Enter your Username: ");
                        string userName = Console.ReadLine();
                        Console.Write("Enter your Phone Number: ");
                        long phoneNo = long.Parse(Console.ReadLine());
                        Console.Write("Enter your Mail ID: ");
                        string mail = Console.ReadLine();
                        EBCalc obj = new EBCalc(userName, phoneNo, mail);
                        EbList.Add(obj);
                        Console.WriteLine("You info saved!");
                        Console.WriteLine("Your Id id : " + obj.mID);
                        break;
                    }

                case 2:
                    {
                        foreach (EBCalc obj in EbList)
                        {
                            Console.Write("Enter your Meter ID: ");
                            string id = Console.ReadLine();
                            if (obj.mID == id)
                            {
                                Console.WriteLine($"Welcome {obj.userName}!");
                                int ch;
                                do
                                {
                                    Console.WriteLine("Enter your option\n1. Calculate Amount \n2. Display user Details \n3. Exit");
                                    ch = int.Parse(Console.ReadLine());
                                    if (ch == 1)
                                    {
                                        obj.units = EBCalc.Calculator();
                                        Console.WriteLine($"Hi {obj.userName}! Your amount is Rs.{obj.units} that you have to Pay");
                                        obj.CalcDisplay();
                                        Console.WriteLine("Your Bill Id is : " + obj.bId);
                                    }
                                    else if (ch == 2)
                                    {
                                        obj.Display();
                                    }
                                    else if (ch == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input Please try again! ");
                                    }
                                } while (ch != 3);
                            }
                        }
                        break;
                    }
            }
        } while (choice != 3);
    }
}