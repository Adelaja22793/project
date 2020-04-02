using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Students
{
    public class Form8
    {
        public int Id { get; set; }
        public int StudentSetUpId { get; set; }
        public string WorkExperience { get; set; }

        public int? EmployerSupervisorId { get; set; }
        public DateTime DateIn { get; set; }
        public string Performance { get; set; }
        public string Reason { get; set; }
        public string StudentExperience { get; set; }
        public string StudentAccept { get; set; }
        public string ReasonNot { get; set; }
        public string FutureEmploy { get; set; }
        public bool SupApproved { get; set; }

        public int? InstitutionOfficerId { get; set; }
        public DateTime InDate { get; set; }
        public string CompanyAssessment { get; set; }
        public string StudentInvolvement { get; set; }
        public string StudentInvolvementComment { get; set; }
        public string GradingPerformance { get; set; }
        public string GradingPerformanceComment { get; set; }
        public bool InstSupApproved { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
        public Setup.InstitutionOfficer InstitutionOfficer { get; set; }
    }
}
