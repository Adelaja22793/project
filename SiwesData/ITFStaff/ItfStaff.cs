using System;
using System.Collections.Generic;
using System.Text;

namespace SiwesData.ITFStaff
{
  public  class ItfStaff
    {
        public int Id { get; set; }
        public string StaffId { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Gradelvl { get; set; }
        public string OfficeCode { get; set; }

        public string Email { get; set; }
        public Boolean Suspended { get; set; }

    }
}
