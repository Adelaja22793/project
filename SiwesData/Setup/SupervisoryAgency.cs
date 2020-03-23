using System;
using System.Collections.Generic;
using System.Text;

namespace SiwesData.Setup
{
    public class SupervisoryAgency
    {
        public int Id { get; set; }
        public Boolean Deactivate { get; set; }
        public DateTime DateActivated { get; set; }
        public int AgencySuperSetupId { get; set; }
        public string StaffId { get; set; }
        public string AgencyOfficerName { get; set; }
        public string AgencyOfficerDesig { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? NationalityId { get; set; }
        public int? StatesId { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public Setup.AgencySuperSetup AgencySuperSetup { get; set; }
        public Setup.Nationality Nationality { get; set; }
        public Setup.State States { get; set; }
    }
}
