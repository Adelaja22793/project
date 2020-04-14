using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SiwesData
{
   public class AppUserTab: IdentityUser
    {
       public string RealName { get; set; }
       public string EmpRcNo { get; set; }
    }
}
