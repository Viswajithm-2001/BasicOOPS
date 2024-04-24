using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum Gender{select,male,female}
    public class Beneficiary
    {
        private static int s_regNo = 1000;
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public Gender Gender {get; set;}
        public int Age {get; set;}
        public string MobileNumber {get; set;}
        public string City { get; set; }

        public Beneficiary(string name,int age,Gender gender,string mobileNumber,string city)
        {
            RegistrationNumber = "BID"+(++s_regNo);
            Name = name;
            Age = age;
            Gender = gender;
            MobileNumber = mobileNumber;
            City = city;
        }
        
}
}