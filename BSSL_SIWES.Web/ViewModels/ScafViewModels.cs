using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSSL_SIWES.Web.ViewModels
{
    public class ScafViewModels
    {
        [Required(ErrorMessage = "Please Enter Student Matric Number")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please Enter Commencement Date")]
        public DateTime CommenceDate { get; set; }
        [Required(ErrorMessage = "Please Enter Completion Date")]
        public DateTime CompletionDate { get; set; }
        public string Duration { get; set; }
        [Required(ErrorMessage = "Please Enter Employer Supervisor Name")]
        public int EmployerSupervisorId { get; set; }
        [Required(ErrorMessage = "Please Enter Comment")]
        public string Remarks { get; set; }
    }
}
