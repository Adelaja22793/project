﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SiwesData.Setup
{
    public class InstitutionOfficer
    {
        public int Id { get; set; }
        public Boolean Deactivate { get; set; }
        public DateTime DateActivated { get; set; }
        public int InstitutionId { get; set; }
        public string OfficerType { get; set; }
        public string StaffId { get; set; }
        public string IntOfficerName { get; set; }
        public string IntOfficerDesig { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? LGAId { get; set; }
       // public int? StatesId { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int? BankSetUpId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string SwitchCode { get; set; }
        public int? NumberOfStudent { get; set; }
        public string ReasonDeactivate { get; set; }

        public Institution Institution { get; set; }
        public LGA LGA { get; set; }
        public BankSetUp BankSetUp { get; set; }
    }
}
