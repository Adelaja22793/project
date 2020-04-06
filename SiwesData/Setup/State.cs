using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class State
    {
        public int Id { get; set; }
        [DisplayName("State")]
        public string Name { get; set; }
        [DisplayName("Nationality")]
        public string Code { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public ICollection<LGA> LGAs { get; set; }
    }
}
