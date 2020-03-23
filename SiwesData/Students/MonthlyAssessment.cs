using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Students
{
    public class MonthlyAssessment
    {
        public int Id { get; set; }
        public int StudentSetUpId { get; set; }
        public string AssessmentMonth { get; set; }
        public DateTime AssessmentDate { get; set; }
        public string MonthlyRemarksByStudent { get; set; }
        public int EmployerSupervisorId { get; set; }
        public DateTime DateAssessed { get; set; }
        public string SupervisorRemarks { get; set; }
        public bool Approved { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
    }
}
