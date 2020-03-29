using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class InstCarryCap
    {
        public int Id { get; set; }
        public string basecarry{ get; set; }
        public int CarryCap { get; set; }
        public Courses Courses { get; set; }
        public CourseGrpSetup CourseGrpSetup { get; set; }
        public Institution Institution { get; set; }

    }
}
