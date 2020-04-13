using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiwesData.Employer
{
    public class EmployerSetupMain
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please RC Number")]
        public string Code { get; set; }
        public string ShortCode { get; set; }
        [Required(ErrorMessage = "Please Company's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Company's Official Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        //[Required(ErrorMessage = "Please Select Resident Country")]
        //public int NationalityId { get; set; }
        //public int StateId { get; set; }
        [Required(ErrorMessage = "Please Select Resident City")]
        public int LGAId { get; set; }
        [Required(ErrorMessage = "Please Select Coprration Type")]
        public string CoporationType { get; set; }
        [Required(ErrorMessage = "Please Enter Business Type")]
        public string BusinessType { get; set; }
        [Required(ErrorMessage = "Please Select Business Line")]
        public int BusinessLineId { get; set; }
        [Required(ErrorMessage = "Please Company's Phone No.")]
        public string PhoneNo { get; set; }
        public string PhoneNo2 { get; set; }
        [Required(ErrorMessage = "Please Company's Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Company's Web Address")]
        public string WebAddress { get; set; }
        [Required(ErrorMessage = "Please Company's Year of Incoporation")]
        public string YearOfIncop { get; set; }
        [Required(ErrorMessage = "Please Select the Closest ITF Area Office")]
        public int AreaOfficeId { get; set; }


        public Setup.AreaOffice AreaOffice { get; set; }
        public Setup.BusinessLine BusinessLine { get; set; }
        //public Setup.Nationality Nationality { get; set; }
        //public Setup.State State { get; set; }
        public Setup.LGA LGA { get; set; }
    }
}
