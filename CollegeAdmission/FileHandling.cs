using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("AdmissionDetails"))
            {
                System.Console.WriteLine("Creating folder for admission details..");
                Directory.CreateDirectory("AdmissionDetails");
            }
            //Creating file for StudentInfo
            if(!File.Exists("AdmissionDetails/StudentInfo.csv"))
            {
                System.Console.WriteLine("Creating csv file for student info....");
                File.Create("AdmissionDetails/StudentInfo.csv").Close();
            }
            //creating file for department info
            if(!File.Exists("AdmissionDetails/DepartmentInfo.csv"))
            {
                System.Console.WriteLine("Creating csv file for department info....");
                File.Create("AdmissionDetails/DepartmentInfo.csv").Close();
            }
            //File for Admission info
            if(!File.Exists("AdmissionDetails/AdmissionInfo.csv"))
            {
                System.Console.WriteLine("Creating file for Admission info....");
                File.Create("AdmissionDetails/AdmissionInfo.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //Students Info
            string[] students = new string[Operations.stdList.Count];
            for(int i=0;i<Operations.stdList.Count;i++)
            {
                students[i] = $"{Operations.stdList[i].studentId},{Operations.stdList[i].studentName},{Operations.stdList[i].fatherName},{Operations.stdList[i].dob.ToString("dd/MM/yyyy")},{Operations.stdList[i].gender},{Operations.stdList[i].pMark},{Operations.stdList[i].cMark},{Operations.stdList[i].mMark}";
            }
            File.WriteAllLines("AdmissionDetails/StudentInfo.csv",students);

            string [] admission = new string[Operations.admList.Count];
            for(int i=0;i<Operations.admList.Count;i++)
            {
                admission[i] = $"{Operations.admList[i].admissionID},{Operations.admList[i].studentId},{Operations.admList[i].deptID},{Operations.admList[i].date.ToString("dd/MM/yyyy")},{Operations.admList[i].admissionStat}";
            }
            File.WriteAllLines("AdmissionDetails/AdmissionInfo.csv",admission);
        }

        public static void ReadFromCSV()
        {
            string []students = File.ReadAllLines("AdmissionDetails/StudentInfo.csv");
            foreach(string student in students)
            {

                StudentDetails student1 = new StudentDetails(student);
                Operations.stdList.Add(student1);
            }
            string []admissions = File.ReadAllLines("AdmissionDetails/AdmissionInfo.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1 = new AdmissionDetails(admission);
                Operations.admList.Add(admission1);
            }
        }
        
    }
}