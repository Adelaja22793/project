using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class InstLevelStudy
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }
        public string Duration { get; set; }
        public Institution Institution { get; set; }
    }
}
