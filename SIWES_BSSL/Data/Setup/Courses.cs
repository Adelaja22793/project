using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIWES_BSSL.Data.Setup
{
    public class Courses
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public int CourseGrpSetupId { get; set; }
        public CourseGrpSetup CourseGrpSetup { get; set; }
    }
}
