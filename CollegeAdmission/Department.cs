using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class Department
    {
        public static int _dID101 = 29;
        public static int _dID102 = 29;
        public static int _dID103 = 30;
        public static int _dID104 = 30;

        public static void SeatsAvailable()
        {
            Console.WriteLine("Department name\t\tNumber of Seats\t\tDepartMent ID\t\tAvailability");
            Console.WriteLine("\t EEE\t\t" + _dID101 + "\t\t\tDID101\t\t\t  " + ((_dID101 > 0) ? "Available" : "Not Available"));
            Console.WriteLine("\t CSE\t\t" + _dID102 + "\t\t\tDID102\t\t\t  " + ((_dID102 > 0) ? "Available" : "Not Available"));
            Console.WriteLine("\tMECH\t\t" + _dID103 + "\t\t\tDID103\t\t\t  " + ((_dID103 > 0) ? "Available" : "Not Available"));
            Console.WriteLine("\t ECE\t\t" + _dID104 + "\t\t\tDID104\t\t\t  " + ((_dID104 > 0) ? "Available" : "Not Available"));
        }

    }
}