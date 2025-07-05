using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    internal class DCProgram
    {
        public string ProgramName { get; set; }
        public int ProgramFees { get; set; }
        public int ProgramDuration { get; set; }

        public DCProgram(string programName, int programFees, int programDuration)
        {
            ProgramName = programName;
            ProgramFees = programFees;
            ProgramDuration = programDuration;
        }
    }
}
