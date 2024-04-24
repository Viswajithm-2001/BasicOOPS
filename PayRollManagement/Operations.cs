using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollManagement
{
    public static class Operations
    {
        static List<EmployeeDetail> employeesList = new List<EmployeeDetail>();
        static List<AttendanceDetail> attendaceList = new List<AttendanceDetail>();
        static EmployeeDetail currentLoggedInEmployee;
        public static void MainMenu()
        {
            //Need to get choice for mainmenu 1. Registration 2. Login 3. Exit
            Console.WriteLine("*****Welcome to Syncfusion Software Private Limited*****");
            string mainChoice = "yes";
            do
            {
                Console.WriteLine("Enter\n1. Employee Registration\n2. Employee Login\n3. Exit");
                Console.Write("Enter the option : ");
                int menuChoice = int.Parse(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        {
                            EmployeeRegistration();
                            break;
                        }
                    case 2:
                        {
                            EmployeeLogin();
                            break;
                        }
                    case 3:
                        {
                            mainChoice = "no";
                            Console.WriteLine("Application Exited Successfully!");
                            break;
                        }
                }
            } while (mainChoice == "yes");
        }
        static void EmployeeRegistration()
        {
            Console.WriteLine("Registration Portal....");
            Console.Write("Enter your Fullname : ");
            string fullName = Console.ReadLine();
            Console.Write("Enter your Date of Birth (dd/MM/yyyy): ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter you Mobile Number : ");
            long mobNum = long.Parse(Console.ReadLine());
            Console.Write("Enter your Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your Branch (Eymard, Karuna, Madhura) : ");
            Branch branch = Enum.Parse<Branch>(Console.ReadLine(),true);
            Console.Write("Enter your Team Name (Network, Hardware, Developer, Facility) : ");
            Team team = Enum.Parse<Team>(Console.ReadLine(),true);

            EmployeeDetail employee = new EmployeeDetail(fullName, dob, mobNum, gender, branch, team);
            employeesList.Add(employee);
            Console.WriteLine("Employee added successfully your id is:  " + employee.EmployeeId);

        }
        static void EmployeeLogin()
        {
            Console.WriteLine("*****Employee Login*****");
            Console.Write("Enter your EmployeeID : ");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (EmployeeDetail employee in employeesList)
            {
                if (employee.EmployeeId == loginID)
                {
                    flag = false;
                    currentLoggedInEmployee = employee;
                    System.Console.WriteLine("You have successfully logged in");
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Employee ID or Not existed");
            }

        }
        static void SubMenu()
        {
            string choice = "no";

            do
            {
                Console.WriteLine("Enter\n1. Add Attendance\n2. Display Details\n3. Calculate Salary\n4. Exit");
                Console.Write("Enter your option : ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            AddAttendance();
                            break;
                        }
                    case 2:
                        {
                            DisplayDetails();
                            break;
                        }
                    case 3:
                        {
                            CalculateSalary();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Do you want to continue (yes/no) : ");
                            choice = Console.ReadLine();
                            Console.WriteLine("Taking back to Main Menu");
                            break;
                        }
                }
            } while (choice == "yes");

        }
        static void AddAttendance()
        {
            Console.Write("Enter the Date : ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter the time for check-in time(hh:mm AM/PM) : ");
            DateTime checkin = DateTime.ParseExact(Console.ReadLine(), "hh:mm tt", null);
            Console.Write("Enter the check out Time (hh:mm AM/PM) : ");
            DateTime checkout = DateTime.ParseExact(Console.ReadLine(), "hh:mm tt", null);
            TimeSpan workTime = checkout - checkin;

            AttendanceDetail attendance = new AttendanceDetail(currentLoggedInEmployee.EmployeeId, date, checkin, checkout);
            if (workTime.TotalHours > 8)
            {
                workTime = TimeSpan.FromHours(8);
            }
            attendance.HoursWorked = workTime;
            attendaceList.Add(attendance);
            Console.WriteLine($"Check-in and Checkout Successful and today you have worked {attendance.HoursWorked.TotalHours} Hours");
        }
        static void DisplayDetails()
        {
            currentLoggedInEmployee.ShowDetails();
        }
        static void CalculateSalary()
        {
            foreach(AttendanceDetail attendance in attendaceList)
            {
                if(currentLoggedInEmployee.EmployeeId == attendance.EmployeeID)
                {
                    Console.WriteLine("Your this month salary should be : "+(attendance.HoursWorked * 500));
                }
            }
        }
    }
}