using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Employer
{
    public class EmployerSupervisor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Officer Name")]
        public string Name { get; set; }
        public string IndBaseCode{ get; set; }
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please Officer Phone")]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        [Required(ErrorMessage = "Please Officer Email")]
        public string Email { get; set; }
        public int? EmployerSuperSetupId { get; set; }
        
        public EmployerSuperSetup EmployerSuperSetup { get; set; }
        
    }
}
