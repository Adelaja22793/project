using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Students
{
    public class DailyActivities
    {
        public int Id { get; set; }
        public int StudentSetUpId { get; set; }
        public DateTime WeekendDate { get; set; }
        public string Day1 { get; set; }
        public string Day1Description { get; set; }
        public string Day2 { get; set; }
        public string Day2Description { get; set; }
        public string Day3 { get; set; }
        public string Day3Description { get; set; }
        public string Day4 { get; set; }
        public string Day4Description { get; set; }
        public string Day5 { get; set; }
        public string Day5Description { get; set; }
        public string Remarks { get; set; }
        public int EmployerSupervisorId { get; set; }
        public DateTime CerifiedDate { get; set; }
        public string SupervisorRemarks { get; set; }
        public bool Approved { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
    }
}
