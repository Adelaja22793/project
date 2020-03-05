using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SIWES_BSSL
{
    public class Indus_MonthlyAssessmentModel : PageModel
    {
        public List<SelectListItem> SelectMonth { get; set; }
        public List<SelectListItem> StudentName { get; set; }
        public void OnGet()
        {

            SelectMonth = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "January" },
                new SelectListItem { Value = "2", Text = "February" },
                new SelectListItem { Value = "3", Text = "March" },
                new SelectListItem { Value = "4", Text = "April" },
                new SelectListItem { Value = "5", Text = "May" },
                new SelectListItem { Value = "6", Text = "June" },
                new SelectListItem { Value = "7", Text = "July" },
                new SelectListItem { Value = "8", Text = "August" },
                new SelectListItem { Value = "9", Text = "September" },
                new SelectListItem { Value = "10", Text = "October" },
                new SelectListItem { Value = "11", Text = "November" },
                new SelectListItem { Value = "12", Text = "December" },
            };
            StudentName = new List<SelectListItem>
            {
                new SelectListItem { Value = "Mr.", Text = "Ceaser Azpilicueta" },
                new SelectListItem { Value = "Mrs.", Text = "Christain Pulisic" },
                new SelectListItem { Value = "Doctor", Text = "Hakim Zyech" },
                new SelectListItem { Value = "Prof.", Text = "Mason Mount" },
                new SelectListItem { Value = "Engr.", Text = "Rose Barkley" },
                new SelectListItem { Value = "Master", Text = "Ngolo Kante" },
                new SelectListItem { Value = "Miss", Text = "Marcos Alonso" },
            };
        }
    }
}