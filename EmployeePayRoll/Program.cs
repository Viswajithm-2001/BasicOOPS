using System;
using System.Collections.Generic;

namespace EmployeePayRoll;

class Program{
    public static void Main(string[] args)
    {
        List<Employee> employeeList = new List<Employee>();
        Console.WriteLine("Main Menu:");
        int choice;
        do{
            Console.WriteLine("Enter\n1.Registration\n2.Login\n3.Exit");
            choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                {
                    Employee emp = new Employee();
                    Console.WriteLine("Registration Page");
                    Console.Write("Enter your name: ");
                    emp.e_name = Console.ReadLine();
                    Console.Write("Enter your Role: ");
                    emp.role = Console.ReadLine();
                    Console.Write("Enter your Work Location as int this list(eymard_chennai/mathuratowers_chennai/kisumu/morrisvelle)");
                    emp.location = Enum.Parse<Work>(Console.ReadLine());
                    Console.Write("Enter your Team name: ");
                    emp.teamName = Console.ReadLine();
                    Console.Write("Enter your Date of Joining(dd/MM/yyyy): ");
                    emp.dateOfJoining = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.Write("Enter the number of Working Days in Month: ");
                    emp.workingDays=int.Parse(Console.ReadLine());
                    Console.Write("Enter number of leaves Taken: ");
                    emp.leaveTaken=int.Parse(Console.ReadLine());
                    Console.Write("Enter your Gender(male/female): ");
                    emp.gender = Enum.Parse<Gender>(Console.ReadLine());
                    Console.WriteLine("Your info have been saved!");
                    Console.WriteLine("Here is your Employee ID: "+ emp.eID+" You can use it for Login");
                    employeeList.Add(emp);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Login Page");
                    Console.Write("Enter your EmployeeId: ");
                    string ID = Console.ReadLine();
                    bool flag=false;
                    foreach(Employee emp in employeeList){
                        if(ID==emp.eID)
                        {
                            flag=true;
                            Console.WriteLine("Hi "+emp.e_name);
                            int ch;
                            do{
                                Console.WriteLine("1. Calculate salary\n2. Display details\n3. Exit");
                                ch= int.Parse(Console.ReadLine());
                                switch(ch)
                                {
                                    case 1:
                                    {
                                        Console.WriteLine("Your Salary is : Rs."+((emp.workingDays-emp.leaveTaken)*500));
                                        break;
                                    }
                                    case 2:
                                    {
                                        emp.Print();
                                        break;
                                    }
                                    case 3:
                                    break;
                                    default:
                                    {
                                        Console.WriteLine("Invalid option...");
                                        break;
                                    }
                                }
                            }while(ch!=3);
                        }
                    }
                    if(!flag){
                        Console.WriteLine("Invalid Used Id...");
                        }
                    break;
                }
                case 3:
                break;
                default:
                {
                    Console.WriteLine("Invalid Option...");
                    break;
                }
            }
        }while(choice!=3);
    }
}