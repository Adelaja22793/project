using System;
using System.Collections.Generic;
using System.Text;

namespace SiwesData.Setup
{
    public class NewCourseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateIn { get; set; }
        public int InstitiutionOfficerId { get; set; }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }

        public Setup.InstitutionOfficer InstitiutionOfficer { get; set; }
    }
}
