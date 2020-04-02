using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Students
{
    public class SupervisorVisit
    {
        public int Id { get; set; }
        public DateTime DateVisited { get; set; }
        public int StudentSetUpId { get; set; }
        public string AreaToImprove { get; set; }
        public string StudentInvolvement { get; set; }
        //public int InstitutionOfficerId { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
       // public Setup.InstitutionOfficer InstitutionOfficer { get; set; }
    }
}
