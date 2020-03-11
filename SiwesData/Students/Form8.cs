using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Students
{
    public class Form8
    {
        public int Id { get; set; }
        public int StudentSetUpId { get; set; }
        public DateTime  Date_Filled { get; set; }
        public DateTime Commence_Date { get; set; }
        public DateTime Complete_Date { get; set; }
        public int Duration { get; set; }
        public string TotalWeeks { get; set; }
        public string WorkExperience { get; set; }
        public int EmployerSupervisorId { get; set; }
        public DateTime DateIn { get; set; }
        public int Performance { get; set; }
        public int StudentExperience { get; set; }
        public string StudentExperienceNo { get; set; }
        public int StudentAccept { get; set; }
        public string StudentAcceptNo { get; set; }
        public string FutureEmploy { get; set; }
        public bool SupApproved { get; set; }
        public int InstSupervisorId { get; set; }
        public DateTime InDate { get; set; }
        public int Assessment { get; set; }
        public int StudentInvolvement { get; set; }
        public string StudentInvolvementComment { get; set; }
        public int GradingPerformance { get; set; }
        public string GradingPerformanceComment { get; set; }
        public bool InstSupApproved { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
        //public InstSupervisor Supervisor { get; set; }
    }
}
