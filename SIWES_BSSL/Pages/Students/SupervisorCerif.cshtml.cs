using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SIWES_BSSL
{
    public class SupervisorCerifModel : PageModel
    {
        public List<SelectListItem> StudentName { get; set; }
        public void OnGet()
        {
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