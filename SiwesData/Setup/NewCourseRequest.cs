using System;
using System.Collections.Generic;
using System.Text;

namespace SiwesData.Setup
{
    public class NewCourseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstitiutionOfficerId { get; set; }

        public Setup.InstitutionOfficer InstitiutionOfficer { get; set; }
    }
}
