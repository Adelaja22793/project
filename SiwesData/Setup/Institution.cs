using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class Institution
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Institution Code")]
        public string Code { get; set; }
        public string ShortCode { get; set; }
        [Required(ErrorMessage = "Please Enter Institution Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Institution Name")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Please Select Country")]
        public string Country { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public string City { get; set; }
        public string ZipCode { get; set; }
       // [Required(ErrorMessage = "Please Enter Phone Number")]
       // [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNo1 { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNo2 { get; set; }
       // [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Not a valid Email Address")]
        public string Email { get; set; }
        public string Website { get; set; }
       // [Required(ErrorMessage = "Please Select Agency Supervisory")]
        public string Superagency { get; set; }
       // [Required(ErrorMessage = "Please Select Area Office")]
        public string AreaOffice { get; set; }
       // [Required(ErrorMessage = "Please Select Affiliate Institution")]
        public string AffiliateInst { get; set; }
        [Required(ErrorMessage = "Please Enter Capacity No")]
        public int CapacityNo { get; set; }
        public string Deactivate { get; set; }
        public DateTime? Datedectivated { get; set; }
        [Required(ErrorMessage = "Please Select Institution Type")]
        public int InstTypeSetupId { get; set; }
        public InstTypeSetup InstTypeSetup { get; set; }
    }
}
