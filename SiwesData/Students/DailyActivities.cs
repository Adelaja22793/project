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
        public string WeekNumber { get; set; }
        public int? EmployerSupervisorId { get; set; }
        public DateTime? CerifiedDate { get; set; }
        public string SupervisorRemarks { get; set; }
        public bool Approved { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
        public Employer.EmployerSupervisor EmployerSupervisor { get; set; }
        public ICollection<DailyActivitiesList> DailyActivitiesLists { get; set; }
    }
}
