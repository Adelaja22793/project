using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SIWES_BSSL.Data;
using SIWES_BSSL.Data.Setup;

namespace SIWES_BSSL
{
    public class IndexModel : PageModel
    {
        private readonly SIWES_BSSL.Data.ApplicationDbContext _context;

        public IndexModel(SIWES_BSSL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Courses> Courses { get;set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.CourseGrpSetup).ToListAsync();
        }
    }
}
