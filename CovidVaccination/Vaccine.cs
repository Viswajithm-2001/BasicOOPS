using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum VaccineName {Covishield, Covaccine}
    public class Vaccine
    {
        private static int s_vaccineID = 2000;
        public string VaccineID { get; }
        public int NoOfDoseAvailable { get; set; }
        public VaccineName VaccineName { get; set; }

        public Vaccine(VaccineName vaccine,int noOfDose)
        {
            VaccineID = "VID"+(++s_vaccineID);
            NoOfDoseAvailable = noOfDose;
            VaccineName = vaccine;
        }
    }
}