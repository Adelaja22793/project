﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Setup
{
    public class CourseGrpSetup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string InstTypeId { get; set; }
        public InstTypeSetup InstTypeSetup { get; set; }
    }
}