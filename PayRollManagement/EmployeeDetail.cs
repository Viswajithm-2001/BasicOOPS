using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollManagement
{
    /// <summary>
    /// this is enum used to collect particular type
    /// </summary> 
    public enum Team{Network, Hardware, Developer, Facility}
    ///<summary>
    ///This enum used to collect the branch, user should only give eymard,mathura,karuna.
    ///<see cref="Branch"/>  
    /// </summary>
    public enum Branch {Eymard,Karuna,Madhura}
    public enum Gender{Male,Female,Transgender}
    /// <summary>
        /// This class used to perform storing employee details 
        /// <see cref="EmployeeDetail"/>
        /// </summary>
    public class EmployeeDetail
    {
        /// <summary>
        /// This class used to perform storing employee's ID value detail
        /// <see cref="EmployeeDetail.s_eId"/>
        /// </summary>
        private static int s_eId=3000;//Field to auto increment
        /// <summary>
        /// This class used to perform storing employee's ID can be accessible from any class detail
        /// <see cref="EmployeeDetail.employeeId"/>
        /// </summary>
        public string EmployeeId;
        /// <summary>
        /// This class used to perform storing employee's fullName detail 
        /// <see cref="EmployeeDetail.fullName"/>
        /// </summary>
        public string fullName;
        /// <summary>
        /// This class used to perform storing employee's date of birth detail 
        /// <see cref="EmployeeDetail.dob"/>
        /// </summary>
        public DateTime dob;
        /// <summary>
        /// This class used to perform storing employee's mobile number detail 
        /// <see cref="EmployeeDetail.mobNumber"/>
        /// </summary>
        public long mobNumber;
        /// <summary>
        /// This class used to perform storing employee's Gender detail
        /// <see cref="EmployeeDetail.gender"/>
        /// </summary>
        public Gender gender;
        /// <summary>
        /// This class used to perform storing employee's branch detail from enum <see cref="Branch"/> 
        /// <see cref="EmployeeDetail.branch"/>
        /// </summary>
        public Branch branch;
        /// <summary>
        /// This class used to perform storing employee's Team detail <see cref="Team"/>
        /// <see cref="EmployeeDetail.team"/>
        /// </summary>
        public Team team;
        /// <summary>
        /// This class used to perform storing employee details as a constructor
        /// <see cref="EmployeeDetail.EmployeeDetail(string, DateTime, long, string, Branch, Team)"/>
        /// </summary>
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="dob"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="Gender"></param>
        /// <param name="branch"></param>
        /// <param name="team"></param>
        public EmployeeDetail(string fullName,DateTime dob,long mobileNumber,Gender Gender,Branch branch,Team team)
        {
            this.fullName = fullName;
            this.dob=dob;
            this.mobNumber=mobileNumber;
            this.gender=Gender;
            this.branch=branch;
            this.team=team;
            EmployeeId = "SF"+(++s_eId);
        }

        public void ShowDetails()
        {
            Console.WriteLine("Your Name : "+fullName);
            Console.WriteLine("Date of Birth : "+dob.ToString("dd/MM/yyyy"));
            Console.WriteLine("Your Gender : "+gender);
            Console.WriteLine("Your Branch : "+branch);
            Console.WriteLine("Your Team : "+team);
            
        }
        

    }
}