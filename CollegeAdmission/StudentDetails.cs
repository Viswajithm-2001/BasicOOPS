using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// enum value for storing particular data such as Male,Female,Transgender
    /// </summary>
    public enum Gender { Select, Male, Female, Transgender }

    /// <summary>
    /// Class <see cref="StudentDetails"/>
    /// Used to store details of student for college admission
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// Class <see cref="StudentDetails._studID"/>
        /// Used to store details of student for college admission
        /// </summary>
        private static int _studID = 3000;
        /// <summary>
        /// Class <see cref="StudentDetails.studentName"/>
        /// Used to store details of student for college admission
        /// </summary>
        public string studentName;
        /// <summary>
        /// Class <see cref="StudentDetails"/>
        /// Used to store details of student for college admission
        /// </summary>
        public string fatherName;
        /// <summary>
        /// Class <see cref="StudentDetails"/>
        /// Used to store details of student for college admission
        /// </summary>
        public DateTime dob;
        /// <summary>
        /// Class <see cref="StudentDetails"/>
        /// Used to store details of student for college admission
        /// </summary>
        public Gender gender;
        /// <summary>
        /// Class <see cref="StudentDetails"/>
        /// Used to store details of student for college admission
        /// </summary>
        public int pMark, cMark, mMark;
        public string studentId;
        public bool admitted;
        public string depid;
        /// <summary>
        /// Parameterised constructor for storing values to class from local variables <see cref="StudentDetails.StudentDetails(string, string, DateTime, Gender, int, int, int)"/>
        /// </summary>
        /// <param name="studentName"></param>
        /// <param name="fatherName"></param>
        /// <param name="date"></param>
        /// <param name="gender"></param>
        /// <param name="pMark"></param>
        /// <param name="cMark"></param>
        /// <param name="mMark"></param>
        public StudentDetails(string studentName, string fatherName, DateTime date, Gender gender, int pMark, int cMark, int mMark)
        {
            this.studentName = studentName;
            this.fatherName = fatherName;
            this.dob = date;
            this.gender = gender;
            this.pMark = pMark;
            this.cMark = cMark;
            this.mMark = mMark;
            studentId = "SF" + (++_studID);
        }
        public StudentDetails(string studentDetail)
        {
            string [] stdDetail = studentDetail.Split(",");
            studentId = stdDetail[0];
            _studID = int.Parse(stdDetail[0].Remove(0,2));
            studentName = stdDetail[1];
            fatherName = stdDetail[2];
            dob = DateTime.Parse(stdDetail[3]);
            gender = Enum.Parse<Gender>(stdDetail[4],true);
            pMark = int.Parse(stdDetail[5]);
            cMark = int.Parse(stdDetail[6]);
            mMark = int.Parse(stdDetail[7]);
        }

        public bool IsEligible()
        {
            double avg = (pMark + cMark + mMark) / 3;
            if (avg >= 75.0)
            {
                return true;
            }
            return false;

        }
        public void ShowDetails()
        {
            Console.WriteLine("Here are the student Details....");
            Console.WriteLine("Student Name : " + studentName);
            Console.WriteLine("Student's father name : " + fatherName);
            Console.WriteLine("Your Date of birth : " + dob.ToString("dd/MM/yyyy"));
            Console.WriteLine("Your Gender : " + gender.ToString());
            Console.WriteLine("Your Physics Mark : " + pMark);
            Console.WriteLine("Your Chemistry Mark : " + cMark);
            Console.WriteLine("Your Maths Mark : " + mMark);
        }
        public void TakeAdmission(string input)
        {

            if (input == "DID101" && IsEligible() && (!admitted))
            {
                if (Department._dID101 > 0)
                {
                    depid = input;
                    Department._dID101 -= 1;
                    admitted = true;
                }
                else
                {
                    Console.WriteLine("seats are filled");
                }

            }
            else if (input == "DID102" && IsEligible() && (!admitted))
            {
                if (Department._dID102 > 0)
                {
                    depid = input;
                    Department._dID102 -= 1;
                    admitted = true;
                }
                else
                {
                    Console.WriteLine("seats are filled");
                }
            }
            else if (input == "DID103" && IsEligible() && (!admitted))
            {
                if (Department._dID103 > 0)
                {
                    depid = input;
                    admitted = true;
                    Department._dID103 -= 1;
                }
                else
                {
                    Console.WriteLine("seats are filled");
                }
            }
            else if (input == "DID104" && IsEligible() && (!admitted))
            {
                if (Department._dID104 > 0)
                {
                    depid = input;
                    admitted = true;
                    Department._dID104 -= 1;
                }
                else
                {
                    Console.WriteLine("seats are filled");
                }
            }
            else if (!IsEligible())
            {
                Console.WriteLine("You are not eligible so you can't book");
            }
            else if (admitted)
            {
                Console.WriteLine("You are already Admitted");
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }


        }

    }
}
