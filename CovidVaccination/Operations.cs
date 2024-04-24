using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public static class Operations
    {
        static List<Beneficiary> beneficiaryList = new List<Beneficiary>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();
        static Beneficiary currentLoggedInBeneficiary;
        static int count=0;


        public static void Default()
        {
            Beneficiary beneficiary1 = new Beneficiary("RaviChandran", 21, Gender.male, "8484484", "Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskaran", 21, Gender.male, "8484747", "Chennai");
            beneficiaryList.Add(beneficiary1);
            beneficiaryList.Add(beneficiary2);

            Vaccine vaccine1 = new Vaccine(VaccineName.Covishield, 50);
            Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine, 50);
            vaccineList.Add(vaccine1);
            vaccineList.Add(vaccine2);

            Vaccination vaccination1 = new Vaccination("BID1001", "CID2001", 1, new DateTime(2021, 11, 11));
            Vaccination vaccination2 = new Vaccination("BID1001", "CID2001", 2, new DateTime(2022, 03, 11));
            Vaccination vaccination3 = new Vaccination("BID1002", "CID2002", 1, new DateTime(2022, 04, 04));
            vaccinationList.AddRange(new List<Vaccination> { vaccination1, vaccination2, vaccination3 });
        }



        public static void MainMenu()
        {
            Console.WriteLine("********************Welcome to Syncfusion College*********************");
            //Need to show the main menu option
            string mainChoice = "yes";
            do
            {
                Console.WriteLine("Main Menu\n1. Beneficiary Registration\n2. Login\n3. Get vaccine Info\n4. Exit");
                //Need to get an input from user and validate
                Console.Write("Select an option : ");
                int mainOption = int.Parse(Console.ReadLine());

                //Need to create mainmenu structure

                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("*****Beneficiary Registration*****");
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*****Login*****");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*****Get Vaccine Info*****");
                            GetVaccineInfo();
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

        static void BeneficiaryRegistration()
        {
            Console.Write("ENter your Name : ");
            string Name = Console.ReadLine();
            Console.Write("Enter your Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter your Gender (Male/Female/Transgender): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter your Mobiel number : ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter your CIty : ");
            string city = Console.ReadLine();
            //Need to create an object
            Beneficiary beneficiary = new Beneficiary(Name, age, gender, mobileNumber, city);
            //Need to add the object in the list
            beneficiaryList.Add(beneficiary);
            //Need to display confirmation message and ID.
            Console.WriteLine("Beneficiary Added Successfully and Registration Number is : " + beneficiary.RegistrationNumber);


        }
        static void Login()
        {
            Console.Write("Enter your student ID : ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate by its presence in the list
            bool flag = true;
            foreach (Beneficiary beneficiary in beneficiaryList)
            {
                if (loginID.Equals(beneficiary.RegistrationNumber))
                {
                    flag = false;
                    //Assigning current user to global variable.
                    currentLoggedInBeneficiary = beneficiary;
                    System.Console.WriteLine("Logged in Successfully");
                    //Need to call submenu
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid ID or ID is not Present");
            }

        }

        static void SubMenu()
        {
            Console.WriteLine("*****SubMenu*****");
            System.Console.WriteLine("Select an option\n1. Show My Details\n2. Take Vaccination\n3. My Vaccination History\n4. Next Due Date\n5. Exit");
            Console.Write("Enter your option : ");
            int option = int.Parse(Console.ReadLine());
            string subchoice = "no";
            //Need to show subMenu options
            do
            {
                switch (option)
                {
                    case 1:
                        {
                            System.Console.WriteLine("*****Show My Details*****");
                            ShowMyDetails();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("*****Take vaccination*****");
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("*****My Vaccination History*****");
                            MyVaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("*****Next Due Date*****");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Do you want to Exit (yes/no)");
                            subchoice = Console.ReadLine();
                            break;
                        }
                }
            }while (subchoice != "yes") ;
        }
        
        
        static void ShowMyDetails()
        {
            System.Console.WriteLine($"Name : {currentLoggedInBeneficiary.Name}");
            System.Console.WriteLine($"Age : {currentLoggedInBeneficiary.Age}");
            System.Console.WriteLine($"Gender : {currentLoggedInBeneficiary.Gender}");
            System.Console.WriteLine($"Mobile Number : {currentLoggedInBeneficiary.MobileNumber}");
            System.Console.WriteLine($"City : {currentLoggedInBeneficiary.City}");
        }

        static void TakeVaccination()
        {
            System.Console.WriteLine("Available Vaccines are....");
            GetVaccineInfo();
            Console.Write("Enter the vaccine ID : ");
            VaccineName tempID = Enum.Parse<VaccineName>(Console.ReadLine(),true);
            MyVaccinationHistory();
            if(count<=2)
            {
                if(currentLoggedInBeneficiary.Age>14)
                {
                    Vaccination vaccination = new Vaccination(currentLoggedInBeneficiary.RegistrationNumber,tempID.ToString(),count++,DateTime.Now);
                }
                else
                {
                    System.Console.WriteLine("You cant take the vaccine");
                }
            }
            else
            {
                System.Console.WriteLine("You have completed all vaccines");
            }

        }
        static void MyVaccinationHistory()
        {
            System.Console.WriteLine("VaccinaitonID   RegisterNumber  VaccineID   DoseNumber   VaccinatedDate");
                foreach(Vaccination vaccination in vaccinationList)
                {
                    if(vaccination.RegistrationNumber==currentLoggedInBeneficiary.RegistrationNumber)
                    {
                        count+=1;
                        System.Console.WriteLine($"{vaccination.VaccinationID,-12}{vaccination.RegistrationNumber,-12}{vaccination.VaccineID,-12}{vaccination.DoseNumber,-12}{vaccination.VaccinatedDate.ToString("dd/MM/yyyy"),-12}");
                    }
                }
        }
        static void NextDueDate()
        {
            foreach(Vaccination vaccination in vaccinationList)
            {
                if(vaccination.RegistrationNumber==currentLoggedInBeneficiary.RegistrationNumber)
                {
                    if(vaccination.VaccinatedDate.AddDays(30)<DateTime.Now)
                    {
                        if(vaccination.DoseNumber<=2)
                        {
                            System.Console.WriteLine("You can Take Vaccination...");
                        }
                        else
                        {
                            System.Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("You have to wait until "+vaccination.VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy"));
                    }
                }
            }
        }
        
        static void GetVaccineInfo()
            {
                System.Console.WriteLine("VaccineID   VaccineName   NoOfDoseAvailable");
               foreach(Vaccine vaccine in vaccineList)
               {
                    System.Console.WriteLine($"{vaccine.VaccineID,-10}{vaccine.VaccineName,-10}{vaccine.NoOfDoseAvailable}");
               } 

            }

        }
    }