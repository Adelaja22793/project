using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSSL_SIWES.Web.ViewModels
{
    public class ScafViewModels
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Enter Commencement Date")]
        public DateTime CommenceDate { get; set; }
        [Required(ErrorMessage = "Please Enter Completion Date")]
        public DateTime CompletionDate { get; set; }
        public string Duration { get; set; }
        public int EmployerSupervisorId { get; set; }
        public string Remarks { get; set; }
    }
}
