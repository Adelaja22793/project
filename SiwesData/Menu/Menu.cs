using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Data.Menu
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubMenu> SubMenus { get; set; }
    }
}
