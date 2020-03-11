using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Setup
{
    public class InstLevelStudy
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }
        public int Duration { get; set; }
        public int InstTypeSetupId { get; set; }

        public InstTypeSetup InstTypeSetup { get; set; }
    }
}
