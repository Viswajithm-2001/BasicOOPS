using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public static class Operations
    {
        public static List<StudentDetails> stdList = new List<StudentDetails>();
        public static List<AdmissionDetails> admList = new List<AdmissionDetails>();

        public static void AddDefault()
        {
            StudentDetails st = new StudentDetails("Ravichandran E", "Ettaparajan", DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), Gender.Male, 95, 95, 95);
        st.depid = "DID101";
        st.admitted = true;
        AdmissionDetails ad = new AdmissionDetails(st.studentId, st.depid, DateTime.ParseExact("11/05/2022", "dd/MM/yyyy", null), admissionStatus.Admit);
        stdList.Add(st);
        admList.Add(ad);
        StudentDetails st1 = new StudentDetails("Baskaran S", "Sethurajan", DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), Gender.Male, 95, 95, 95);
        st1.admitted = true;
        st1.depid = "DID102";
        AdmissionDetails ad1 = new AdmissionDetails(st1.studentId, st1.depid, DateTime.ParseExact("11/05/2022", "dd/MM/yyyy", null), admissionStatus.Admit);
        stdList.Add(st1);
        admList.Add(ad1);
        }
        public static void MainMenu()
        {
            int choice;
        Console.WriteLine("Welcome to Syncfusion College of Engineering and Technology");
        do
        {
            Console.WriteLine("Main Menu.....");
            Console.WriteLine("Enter\n1. Student Registration\n2. Student Login\n3. Department wise seat availability\n4. Exit");
            Console.Write("your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("_____Registration_____");
                        Console.Write("Enter StudentName : ");
                        string sname = Console.ReadLine();
                        Console.Write("Enter student's Father Name: ");
                        string fname = Console.ReadLine();
                        Console.Write("Enter date of birth(dd/MM/yyyy): ");
                        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Enter your Gender(Select,Male,Female,Transgender): ");
                        Gender gender = Enum.Parse<Gender>(Console.ReadLine());
                        Console.Write("Enter your Physics mark : ");
                        int pMark = int.Parse(Console.ReadLine());
                        Console.Write("Enter your Chemistry mark : ");
                        int cMark = int.Parse(Console.ReadLine());
                        Console.Write("Enter your Maths mark : ");
                        int mMark = int.Parse(Console.ReadLine());
                        StudentDetails stud = new StudentDetails(sname, fname, dob, gender, pMark, cMark, mMark);
                        stdList.Add(stud);
                        Console.WriteLine("Student Registered Successfully and StudentID is : " + stud.studentId);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("_____Login_____");
                        Console.Write("Enter your Student ID : ");
                        bool isValid = false;
                        string stduId = Console.ReadLine();
                        foreach (StudentDetails student in stdList)
                        {

                            char ch;
                            if (student.studentId == stduId)
                            {
                                isValid = true;
                                do
                                {
                                    Console.WriteLine("Select \na. Check Eligibility\nb. Show Details\nc. Take Admission\nd. Cancel Admission\ne. Show Admission Details\nf. Exit");
                                    Console.Write("Your choice : ");
                                    ch = char.Parse(Console.ReadLine());
                                    switch (ch)
                                    {
                                        case 'a':
                                            {
                                                //check eligibility
                                                if (student.IsEligible())
                                                {
                                                    Console.WriteLine("Student is Eligible..");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Student is not eligible");
                                                }
                                                break;
                                            }
                                        case 'b':
                                            {
                                                //show details
                                                student.ShowDetails();
                                                break;
                                            }
                                        case 'c':
                                            {
                                                //take admission
                                                Department.SeatsAvailable();
                                                Console.WriteLine("Pick one department ID");
                                                Console.Write("Enter department ID: ");
                                                string input = Console.ReadLine();
                                                student.TakeAdmission(input);
                                                AdmissionDetails adm = new AdmissionDetails(stduId, student.depid, DateTime.Now, admissionStatus.Admit);
                                                admList.Add(adm);
                                                Console.WriteLine("Admission took successfully. Your admission ID - " + adm.admissionID);
                                                break;
                                            }
                                        case 'd':
                                            {
                                                //cancel admission
                                                Console.WriteLine("Enter your admission ID: ");
                                                string input = Console.ReadLine();
                                                bool flag = false;
                                                foreach (AdmissionDetails admissions in admList)
                                                {

                                                    if (admissions.admissionID == input && admissions.studentId == student.studentId)
                                                    {
                                                        flag = true;
                                                        Console.WriteLine("Enter Cancel to Cancel");
                                                        Console.Write("Your choice: ");
                                                        admissionStatus stat = Enum.Parse<admissionStatus>(Console.ReadLine());
                                                        if (stat.ToString() == "Cancel")
                                                        {
                                                            admissions.admissionStat = "Cancelled";
                                                            Console.WriteLine("You have successfully cancelled...");
                                                        }
                                                        break;

                                                    }
                                                }
                                                if (!flag)
                                                {
                                                    Console.WriteLine("Invalid ID..");
                                                }
                                                break;
                                            }
                                        case 'e':
                                            {
                                                //show  admission
                                                Console.WriteLine("Admissions lists");
                                                Console.WriteLine("AdmissionID\tStudentID\tDepartmentID\tAdmissionDate\tAdmissionStatus");
                                                foreach (AdmissionDetails admissions in admList)
                                                {
                                                    if (admissions.studentId == student.studentId)
                                                    {
                                                        Console.WriteLine(admissions.admissionID + "          " + admissions.studentId + "          " + admissions.deptID + "           " + admissions.date.ToString("dd/MM/yyyy") + "          " + admissions.admissionStat);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        case 'f':
                                            {
                                                //exit
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Invalid option..");
                                                break;
                                            }
                                    }
                                } while (ch != 'f');
                            }

                        }
                        if (!isValid)
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("_____Seat Availabity_____");
                        Department.SeatsAvailable();
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Choice");
                        break;
                    }
            }


        } while (choice != 4);
        }
    }
}