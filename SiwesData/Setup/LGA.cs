using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class LGA
    {
        public int Id { get; set; }
        [DisplayName("City")]
        public string Name { get; set; }
        [DisplayName("State")]

        public string Code { get; set; }
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public State State { get; set; }
      
    }
}
