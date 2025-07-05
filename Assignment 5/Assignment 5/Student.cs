using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SIN { get; set; }
        public string Email { get; set; }
        public int HighSchoolGrade { get; set; }
        public int AdmissionTestScore { get; set; }
        public string CampusLocation { get; set; }
        public string ProgramName { get; set; }

        public Student(string firstName, string lastName, int sin, string email, int highSchoolGrade, int admissionTestScore, string campusLocation, string programName)
        {
            FirstName = firstName;
            LastName = lastName;
            SIN = sin;
            Email = email;
            HighSchoolGrade = highSchoolGrade;
            AdmissionTestScore = admissionTestScore;
            CampusLocation = campusLocation;
            ProgramName = programName;
        }
    }
}
