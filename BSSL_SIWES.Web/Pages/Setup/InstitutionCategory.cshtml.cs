using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{
    public class InstitutionCategoryModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;

        [BindProperty]
        public InstCatSetup InstCatSetup { get; set; }
        public IList<InstCatSetup> InstCatSetups { get; set; }

        public InstitutionCategoryModel(SiwesData.ApplicationDbContext context)
        {
            _context = context;
        }
        //public class InputModel
        //{
        //    public int Id { get; set; }
        //    [Required(ErrorMessage = "Please Enter Category Code.")]
        //    public string Code { get; set; }
        //    [Required]
        //    public string Name { get; set; }
        //    public Boolean Deactivate { get; set; }
        //}
        //[BindProperty]
        //public InputModel Input { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            InstCatSetups = await _context.InstCatSetup.ToListAsync();
           // return Page();
        }
    }
}