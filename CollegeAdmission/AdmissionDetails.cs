using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum admissionStatus { Select, Admit, Cancel }
    public class AdmissionDetails
    {
        private static int _adID = 1000;
        public string admissionID;
        public string deptID;
        public string studentId;
        public string admissionStat;
        public DateTime date;
        public admissionStatus status;

        public AdmissionDetails(string studID, String deptID, DateTime admDate, admissionStatus status)
        {
            this.studentId = studID;
            this.date = admDate;
            this.deptID = deptID;
            this.status = status;
            admissionID = "AID" + (++_adID);
            if (status == admissionStatus.Admit)
            {
                admissionStat = "Booked";
            }
            else
            {
                admissionStat = "Cancelled";
            }
        }
        public AdmissionDetails(string admission)
        {
            string[] adm = admission.Split(",");
            _adID = int.Parse(adm[0].Remove(0,3));
            admissionID = adm[0];
            this.studentId = adm[1];
            this.deptID = adm[2];
            this.date = DateTime.Parse(adm[3]);
            this.status = adm[4]=="Booked" ? admissionStatus.Admit : (adm[4]=="Cancelled" ? admissionStatus.Cancel : admissionStatus.Select);
            admissionStat = adm[4];
        }


    }
}