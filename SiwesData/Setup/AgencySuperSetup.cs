using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class AgencySuperSetup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Agency Code")]
        public string Code { get; set; }

        public string ShortCode { get; set; }
        [Required(ErrorMessage = "Please Enter Agency Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Select Sate")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public string City { get; set; }
        public string ZipCode { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string WebAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Contact Person Name")]
        public string NameOfCPerson { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string CPersonPhone { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Not a valid Email Address")]
        public string CPersonEmail { get; set; }
        public string Deactivate { get; set; }
        public DateTime? DeactDate { get; set; }
    }
}
