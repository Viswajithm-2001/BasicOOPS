using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    enum admissionStatus { Select, Admit, Cancel }
    public class AdmissionDetail
    {
        private static int _adID = 1000;
        public string admissionID;
        public string deptID;
        public string studentId;
        public string admissionStat;
        public DateTime date;
        bool status;

        public AdmissionDetail(string studID, String deptID, DateTime admDate, bool status)
        {
            this.studentId = studID;
            this.date = admDate;
            this.deptID = deptID;
            this.status = status;
            admissionID = "AID" + (++_adID);
            if (status)
            {
                admissionStat = "Booked";
            }
            else
            {
                admissionStat = "Cancelled";
            }
        }

    }
}