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
        public string Duration { get; set; }
        public int EmployerSupervisorId { get; set; }
        public string Remarks { get; set; }
        public bool Suspended { get; set; }
        public string ReasonSuspended { get; set; }

        public StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
        //public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
    }
}
