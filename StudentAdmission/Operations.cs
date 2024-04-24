using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Static class
    public static class Operations
    {
        //Local/Global Object Creation
        static StudentDetail currentLoggedInStudent;
        static string spacing = "___________________________________________";
        //Static List creation
        static List<StudentDetail> studentList = new List<StudentDetail>();
        static List<AdmissionDetail> admissionList = new List<AdmissionDetail>();
        static List<DepartmentDetail> departmentList = new List<DepartmentDetail>();
        //Main menu
        public static void MainMenu()
        {
            Console.WriteLine("********************Welcome to Syncfusion College*********************");
            //Need to show the main menu option
            string mainChoice = "yes";
            do
            {
                Console.WriteLine("Main Menu\n1. Registration\n2. Login\n3. Department wise seat availability\n4. Exit");
                //Need to get an input from user and validate
                Console.Write("Select an option : ");
                int mainOption = int.Parse(Console.ReadLine());

                //Need to create mainmenu structure

                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("*****Student Registration*****");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*****Student Login*****");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*****Department wise Seat availability*****");
                            DepartmentWiseSeatAvailabibilty();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application exited Succesfully");
                            mainChoice = "no";
                            break;
                        }
                }
            } while (mainChoice != "no");
            //Need to iterate until the option in exit.


        }

        //Registration
        public static void StudentRegistration()
        {
            //Need to get required details
            Console.Write("ENter your Name : ");
            string studentName = Console.ReadLine();
            Console.Write("Enter your Father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Date of Birth (dd/MM/yyyy): ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter your Gender (Male/Female/Transgender): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your Physics Mark : ");
            int physicsMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your Chemistry Mark : ");
            int chemistryMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your Maths Mark : ");
            int mathsMark = int.Parse(Console.ReadLine());
            //Need to create an object
            StudentDetail student = new StudentDetail(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);
            //Need to add the object in the list
            studentList.Add(student);
            //Need to display confirmation message and ID.
            Console.WriteLine("Student Registered Successfully and StudentID is : " + student.StudentID);

        }

        //Login
        public static void StudentLogin()
        {
            //Need to get ID input
            Console.Write("Enter your student ID : ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate by its presence in the list
            bool flag = true;
            foreach (StudentDetail student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    flag = false;
                    //Assigning current user to global variable.
                    currentLoggedInStudent = student;
                    System.Console.WriteLine("Logged in Successfully");
                    //Need to call submenu
                    Submenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid ID or ID is not Present");
            }
            //If not -Invalid.
        }
        //submenu
        public static void Submenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("*****SubMenu*****");
                System.Console.WriteLine("Select an option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Detail\n6. Exit");
                Console.Write("Enter your option : ");
                int option = int.Parse(Console.ReadLine());
                //Need to show subMenu options
                switch (option)
                {
                    case 1:
                        {
                            System.Console.WriteLine("*****Check Eligibility*****");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("*****Show Details*****");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("*****Take Admission*****");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("*****Cancel Admission*****");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("*****Admission Details*****");
                            AdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("Taking back to MainMenu...");
                            subChoice = "no";
                            break;
                        }
                }
                //getting user option
                //Itreate till the option is exit
            } while (subChoice == "yes");
        }
        //Check Eligibility
        public static void CheckEligibility()
        {
            //Need to get Cutoff value as Input
            Console.Write("Enter the cutoff value : ");
            double cutOff = double.Parse(Console.ReadLine());
            //Check eligible or not
            if (currentLoggedInStudent.CheckEligiblity(cutOff))
            {
                Console.WriteLine("Student is eligible");
            }
            else
            {
                Console.WriteLine("Student is not eligible");
            }

        }
        //Show Details
        public static void ShowDetails()
        {
            //Need to show current student's detail
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}|");

        }

        //Take admission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailabibilty();
            //Ask department ID from user
            Console.Write("Select a department ID : ");
            string departmentID = Console.ReadLine().ToUpper();
            //Check the ID present or not
            bool flag = true;
            foreach (DepartmentDetail department in departmentList)
            {
                if (departmentID.Equals(department.DepartmentID))
                {
                    flag = false;
                    //Check student eligible or not
                    if (currentLoggedInStudent.CheckEligiblity(75.0))
                    {
                        //Check the seat availability
                        if (department.NumberOfSeats > 0)
                        {
                            //Check student already taken any admission
                            int count = 0;
                            foreach (AdmissionDetail admission in admissionList)
                            {
                                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                //create admission object 
                                AdmissionDetail admissionTaken = new AdmissionDetail(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                //Reduce seat count.
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(admissionTaken);
                                //Display admission successful message
                                Console.WriteLine("You have taken admission successfully. Admission ID : " + admissionTaken.AdmissionID);
                            }
                            else
                            {
                                Console.WriteLine("You have already taken an admission");
                            }


                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Student is not Eligible");
                    }

                    break;

                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }



        }
        //Cancel admission
        public static void CancelAdmission()
        {
            //Check the student is taken any admission and display it.
            bool flag = true;
            foreach (AdmissionDetail admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag = false;
                    //Cancel founded admission
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    //return the seat to department.
                    foreach (DepartmentDetail department in departmentList)
                    {
                        if (admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }

                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("you have no admission to cancel");
            }


        }
        //Admission details
        public static void AdmissionDetails()
        {
            //Need to show Current logged in student admission details
            System.Console.WriteLine("|Admission ID|Student ID|Department ID|Admission ID|Admission status|");
            foreach (AdmissionDetail admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
                }
            }
        }
        //Department wise seat availability
        public static void DepartmentWiseSeatAvailabibilty()
        {
            //Need to show all department details
            Console.WriteLine("|DepartmentID|Department Name|NumberOfSeat|");
            Console.WriteLine(spacing);
            foreach (DepartmentDetail department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-15}|{department.NumberOfSeats,-12}|");
                Console.WriteLine(spacing);
            }

        }

        //Adding Default Data
        public static void AddDefaultData()
        {
            //Adding Student Detail
            StudentDetail student1 = new StudentDetail("Ravichandran", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetail student2 = new StudentDetail("Baskaran", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.AddRange(new List<StudentDetail> { student1, student2 });

            //Adding department details
            DepartmentDetail department1 = new DepartmentDetail("EEE", 29);
            DepartmentDetail department2 = new DepartmentDetail("CSE", 29);
            DepartmentDetail department3 = new DepartmentDetail("MECH", 30);
            DepartmentDetail department4 = new DepartmentDetail("ECE", 30);
            departmentList.AddRange(new List<DepartmentDetail> { department1, department2, department3, department4 });

            //Adding admission detail
            AdmissionDetail admission1 = new AdmissionDetail(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetail admission2 = new AdmissionDetail(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetail> { admission1, admission2 });

            //Printing the values


            //Default data added
        }


    }
}