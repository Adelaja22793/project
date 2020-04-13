using SiwesData.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Menu
{
    //[Table("SubMenu")]
    public class MenuAccess
    {
        public int Id { get; set; }
        public string RoleId { get; set; }

        public int SubMenuId { get; set; }
        //public int MenuId { get; set; }

        //public Menu Menu { get; set; }   
        //public SubMenu SubMenu { get; set; }
        public Menu Menu { get; set; }
        public RoleTb RoleTb { get; set; }
        public bool Active { get; set; }
    }
}
