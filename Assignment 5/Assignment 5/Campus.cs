using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    internal class Campus
    {
        public int HSGradeReq { get; set; }
        public int AdmissionTSReq { get; set; }
        public int RegFees { get; set; }
        public List<DCProgram> ListPrograms { get; set; }

        public Campus(int hsGradeReq, int admissionTSReq, int regFees)
        {
            HSGradeReq = hsGradeReq;
            AdmissionTSReq = admissionTSReq;
            RegFees = regFees;
            ListPrograms = new List<DCProgram>();
        }
    }
}

