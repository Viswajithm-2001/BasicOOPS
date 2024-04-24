using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public enum Gender{male,female};
    public enum Work{eymard_chennai,mathuratowers_chennai,kisumu,morrisvelle};
    public class Employee
    {
        private static int _employeeId=1001;

        public string e_name { get; set; }
        public string role { get; set; }
        public string teamName { get; set; }
        public DateTime dateOfJoining { get; set; }
        public int workingDays { get; set; }
        public int leaveTaken { get; set; }
        public Work location{get; set;}
        public Gender gender { get; set; }
        public string eID;
        public Employee()
        {
            eID = ("SF" +(_employeeId++));
        }
        public void Print(){
            Console.WriteLine("Employee Id : "+eID);
            Console.WriteLine("Role : "+role);
            Console.WriteLine("Work Location"+ location);
            Console.WriteLine("Team Name : "+teamName);
            Console.WriteLine("Date of Joining : "+dateOfJoining.ToString("dd/MM/yyyy"));
            Console.WriteLine("Gender : "+gender);
            Console.WriteLine("Total working days : "+workingDays);
            Console.WriteLine("Leaves Taken : "+ leaveTaken);
        }
    }
}