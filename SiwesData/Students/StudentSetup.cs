using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Students
{
    public class StudentSetUp
    {
        public int Id { get; set; }
        public string MatricNumber { get; set; }
        public string MatricYear { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public int CoursesId { get; set; }
        //public int? InstitutionId { get; set; }
        public int? InstitutionOfficerId { get; set; }
        public string YearOfStudy { get; set; }
        public int? NationalityId { get; set; }
        //public int? LGAId { get; set; }
        //public int? StateId { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public string StudentType { get; set; }
        public string SiwesYear { get; set; }
        public string BatchNo { get; set; }
        public bool Suspended { get; set; }
        public string ReasonSuspended { get; set; }
        public bool Attached { get; set; }

        public Setup.Courses Courses { get; set; }
        public Setup.Nationality Nationalities { get; set; }
        //public Setup.LGA LGA { get; set; }
        public Setup.State State { get; set; }
        public Setup.InstitutionOfficer InstitutionOfficer { get; set; }
    }
}
