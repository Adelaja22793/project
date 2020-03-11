using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Setup
{
    public class State
    {
        public int Id { get; set; }
        [DisplayName("State")]
        public string Name { get; set; }
        [DisplayName("Nationality")]
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
    }
}
