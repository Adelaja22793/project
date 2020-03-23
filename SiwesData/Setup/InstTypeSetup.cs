using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class InstTypeSetup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int InstCatSetupId { get; set; }
        public InstCatSetup InstCatSetup { get; set; }
        public int AgencySuperSetupId { get; set; }
        public AgencySuperSetup AgencySuperSetup { get; set; }
        public ICollection<CourseGrpSetup> CourseGrpSetups { get; set; }
    }
}
