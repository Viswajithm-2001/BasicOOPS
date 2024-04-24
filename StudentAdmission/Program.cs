using System;
namespace StudentAdmission;//File scoped namespace.
class Program
{
    public static void Main(string[] args)
    {
        //Default data calling
        Operations.AddDefaultData();
        //Calling Main menu
        Operations.MainMenu();
    }
}