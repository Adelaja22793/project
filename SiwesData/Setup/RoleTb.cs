using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class RoleTb: IdentityRole
    {
        public string RoleId { get; set; }
    }
}
