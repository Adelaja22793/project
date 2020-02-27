using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIWES_BSSL.Data.Setup
{
    public class PolicyTb
    {
        public int Id { get; set; }

        public string InstypeId { get; set; }
        public Boolean MustNotExcCap { get; set; }
        public int MaxSiwesCap { get; set; }
        public Boolean AllowDisporal { get; set; }
        public Decimal SuperAmt { get; set; }
        public Decimal StudentAmt { get; set; }
        public int MinVisit4Super { get; set; }

        public DateTime MasterListDate { get; set; }
        public Boolean DelistInst { get; set; }
    }
}
