using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BSSL_SIWES.Web.ViewModels
{
    public class CreateStudentsViewModels
{
        [Required(ErrorMessage = "Please Enter Matric No.")]
        public string MatricNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please Enter OtherNames")]
        public string OtherNames { get; set; }
        [Required(ErrorMessage = "Please Select Matric Year")]
        public string MatricYear { get; set; }
        //public int InstitutionOfficerId { get; set; }
        [Required(ErrorMessage = "Please Enter Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select Level of Study")]
        public string LevelStudy { get; set; }
        [Required(ErrorMessage = "Please Select LGA")]
        public int? LGAId { get; set; }
        //public int StateId { get; set; }
        [Required(ErrorMessage = "Please Student Phone no.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Student Email")]
        public string Email { get; set; }
        public string StudentType { get; set; }
        public string SiwesYear { get; set; }
        public string BatchNo { get; set; }

    }
}
