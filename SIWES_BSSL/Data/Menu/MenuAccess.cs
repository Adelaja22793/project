using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIWES_BSSL.Data.Menu
{
    public class MenuAccess
    {
        public int Id { get; set; }
        public string RoleId { get; set; }

        public int SubMenuId { get; set; }
        //public int MenuId { get; set; }

        //public Menu Menu { get; set; }   
        public SubMenu SubMenu { get; set; }
    }
}
