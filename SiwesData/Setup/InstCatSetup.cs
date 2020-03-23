﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Setup
{
    public class InstCatSetup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Boolean Deactivate { get; set; }
        public ICollection<InstTypeSetup> InstTypes { get; set; }
    }
}