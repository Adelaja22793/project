using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIWES_BSSL.Data.InstitiutionOfficer
{
    public class InstitiutionOfficer
    {
        public int InstitiutionId { get; set; }

        public Boolean Deactivate { get; set; }

        public DateTime DateActivated { get; set; }

        public string InstiAddress { get; set; }

        public int OfficerType { get; set; }

        public int OfficerId { get; set; }

        public string OfficerName { get; set; }

        public string OfficerDesig { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ResidentCountry { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public int NumberOfStudent { get; set; }

        public string BankName { get; set; }

        public string AccountNo { get; set; }

        public string AccountName { get; set; }

        public string SwitchCode { get; set; }

        public string Image { get; set; }

    }

}
