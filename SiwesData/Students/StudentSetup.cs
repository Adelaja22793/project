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
        public int? InstitutionId { get; set; }
        public string YearOfStudy { get; set; }
        public int NationalityId { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public Setup.Courses Courses { get; set; }
        public Setup.Nationality Nationalities { get; set; }
        public Setup.Institution Institution { get; set; }
    }
}
