using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class PolicyTb
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Institution Type")]
        public string InstypeId { get; set; }
        public Boolean MustNotExcCap { get; set; }
        public int MaxSiwesCap { get; set; }
        public Boolean AllowDisporal { get; set; }
        public Boolean AllowInternal { get; set; }
        public Decimal SuperAmt { get; set; }
        public Decimal StudentAmt { get; set; }
        public int MinVisit4Super { get; set; }
        [DisplayFormat(DataFormatString ="{dd-MM-yyyy}")]
        public DateTime? MasterListDate { get; set; }
        public Boolean DelistInst { get; set; }
    }
}
