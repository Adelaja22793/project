using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Students
{
    public class Scaf
    {
        public int Id { get; set; }
        //public string RefNo { get; set; }
        //public DateTime Scaf_Date { get; set; }
        public int StudentSetUpId { get; set; }
        public DateTime Commence_Date { get; set; }
        public DateTime Complete_Date { get; set; }
        public int Duration { get; set; }
        public int EmployerSuperSetupId { get; set; }
        public int EmployerSupervisorId { get; set; }
        public string Remarks { get; set; }

        public Students.StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSuperSetup EmployerSuperSetup { get; set; }
        //public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
    }
}
