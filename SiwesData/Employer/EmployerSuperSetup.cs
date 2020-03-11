using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Employer
{
    public class EmployerSuperSetup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string YearOfIncop { get; set; }
        public int AreaOfficeId { get; set; }

        public Setup.AreaOffice AreaOffice { get; set; }
    }
}
