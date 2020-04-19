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
        public int? InstitiutionId { get; set; }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ReqstType { get; set; }
        public string Code { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? LGAId { get; set; }
        public string CoporationType { get; set; }
        public string BusinessType { get; set; }
        public int? BusinessLineId { get; set; }
        public string PhoneNo { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string YearOfIncop { get; set; }
        public int? AreaOfficeId { get; set; }


        public Setup.AreaOffice AreaOffice { get; set; }
        public Setup.BusinessLine BusinessLine { get; set; }
        //public Setup.Nationality Nationality { get; set; }
        //public Setup.State State { get; set; }
        public Setup.LGA LGA { get; set; }
        public Institution Institution { get; set; }
    }
}
