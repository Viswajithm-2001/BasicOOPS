using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollManagement
{
    public class AttendanceDetail
    {
        private static int s_attendanceID=1000;
        public string AttendanceID { get;}
        public string EmployeeID{get;set;}
        public DateTime Date{get;set;}
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime{get;set;}
        public TimeSpan HoursWorked;

        public AttendanceDetail(string employeeID,DateTime date, DateTime checkInTime,DateTime checkOutTime)
        {
            s_attendanceID++;
            AttendanceID = "AID"+ s_attendanceID;
            EmployeeID = employeeID;
            Date = date;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            
        }
    }
}