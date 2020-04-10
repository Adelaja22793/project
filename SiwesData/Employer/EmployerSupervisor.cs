using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiwesData.Employer
{
    public class EmployerSupervisor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IndBaseCode{ get; set; }
        public string IndBaseName { get; set; }
        public string Designation { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string AreaOfficeId { get; set; }
        public int? EmployerSuperSetupId { get; set; }
        
        public EmployerSuperSetup EmployerSuperSetup { get; set; }
        
    }
}
