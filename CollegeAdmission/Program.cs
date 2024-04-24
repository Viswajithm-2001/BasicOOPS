using System;
using System.Collections.Generic;
namespace CollegeAdmission;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();

        //Operations.AddDefault();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();

        FileHandling.WriteToCSV();
        
        
        
    }
}