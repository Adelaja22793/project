﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class Institution
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
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Superagency { get; set; }
        public string AreaOffice { get; set; }
        public string AffiliateInst { get; set; }
        public int CapacityNo { get; set; }
        public string Deactivate { get; set; }
        public DateTime? Datedectivated { get; set; }
        public int InstTypeSetupId { get; set; }
        public InstTypeSetup InstTypeSetup { get; set; }
    }
}
