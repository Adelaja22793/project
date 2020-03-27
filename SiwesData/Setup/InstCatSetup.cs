using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Setup
{
    public class InstCatSetup
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public Boolean Deactivate { get; set; }
       // public ICollection<InstTypeSetup> InstTypes { get; set; }
    }
}
