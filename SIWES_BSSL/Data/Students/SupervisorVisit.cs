using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIWES_BSSL.Data.Students
{
    public class SupervisorVisit
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public DateTime DateVisited { get; set; }
        public int StudentSetUpId { get; set; }
        public string SupervisorRemarks1 { get; set; }
        public string SupervisorRemark2 { get; set; }
        public int NumberOfVisit { get; set; }
        public int SupervisorId { get; set; }

        //navigation properties
        public StudentSetUp StudentSetUp { get; set; }
        //public IntSupervisor Supervisor { get; set; }
    }
}
