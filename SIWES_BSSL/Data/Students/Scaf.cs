using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIWES_BSSL.Data.Students
{
    public class Scaf
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public DateTime Scaf_Date { get; set; }
        public DateTime Commence_Date { get; set; }
        public DateTime Complete_Date { get; set; }
        public int Duration { get; set; }
        public int EmployerSuperSetupId { get; set; }
        public int EmployerSupervisorSetupId { get; set; }
        public string Remarks { get; set; }

        //public Employers.EmployerSuperSetup EmployerSuperSetup { get; set; }
        //public Employers.EmployerSupervisorSetup EmployerSupervisor { get; set; }
    }
}
