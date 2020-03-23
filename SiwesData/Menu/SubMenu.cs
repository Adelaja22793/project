using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Menu
{
    public class SubMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PageUrl { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        //public ICollection<MenuAccess> MenuAccesses { get; set; }
    }
}
