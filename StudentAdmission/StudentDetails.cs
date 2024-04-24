using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender{select,male,female}
    public class StudentDetail
    {
        public string name { get; set; }
        public string fatherName {get; set;}
        public Gender Gender {get; set;}
        public DateTime dob {get; set;}
        public long phoneNumber {get; set;}

        public StudentDetail(){}
        public StudentDetail(string name,string fatherName,DateTime dob){
            this.name = name;
            this.fatherName = fatherName;
            this.dob = dob;
            Console.WriteLine("Enter your number");
            this.phoneNumber = long.Parse(Console.ReadLine());            
        }
        ~StudentDetail(){
            Console.WriteLine("Destroyed");
        }
        public void Print(){
            Console.WriteLine("Your name is: "+name);
        }
    }
}