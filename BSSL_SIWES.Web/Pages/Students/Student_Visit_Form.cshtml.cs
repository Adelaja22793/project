using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BSSL_SIWES.Web
{
    public class Student_Visit_FormModel : PageModel
    {
        public List<SelectListItem> Title { get; set; }
        public void OnGet()
        {
            
            Title = new List<SelectListItem>
            {
                new SelectListItem { Value = "Mr.", Text = "Mr." },
                new SelectListItem { Value = "Mrs.", Text = "Mrs." },
                new SelectListItem { Value = "Doctor", Text = "Doctor" },
                new SelectListItem { Value = "Prof.", Text = "Professor" },
                new SelectListItem { Value = "Engr.", Text = "Engineer" },
                new SelectListItem { Value = "Master", Text = "Master" },
                new SelectListItem { Value = "Miss", Text = "Miss" },
            };
        }
    }
}