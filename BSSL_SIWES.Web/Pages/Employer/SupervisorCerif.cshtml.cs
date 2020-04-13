using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiwesData.Students;
using SiwesData.Employer;

using SiwesData;
namespace BSSL_SIWES.Web.Pages.Employer
{
    public class SupervisorCerifModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly UserManager<AppUserTab> _userManager;

        public SupervisorCerifModel(SiwesData.ApplicationDbContext context,
            UserManager<AppUserTab> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<SelectListItem> StudentName { get; set; }
        public IList<Scaf> Scafs { get; set; }
        public EmployerSupervisor EmployerSupervisor { get; set; }
        public List<SelectListItem> SelectMonth { get; set; }
        public async Task OnGetAsync(int? id)
        {
            id = 3;
            
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
            SelectMonth = new List<SelectListItem>
            {
                new SelectListItem { Value = "January", Text = "January" },
                new SelectListItem { Value = "February", Text = "February" },
                new SelectListItem { Value = "March", Text = "March" },
                new SelectListItem { Value = "April", Text = "April" },
                new SelectListItem { Value = "May", Text = "May" },
                new SelectListItem { Value = "June", Text = "June" },
                new SelectListItem { Value = "July", Text = "July" },
                new SelectListItem { Value = "August", Text = "August" },
                new SelectListItem { Value = "September", Text = "September" },
                new SelectListItem { Value = "October", Text = "October" },
                new SelectListItem { Value = "November", Text = "November" },
                new SelectListItem { Value = "December", Text = "December" },
            };

            //ViewData["NationalityId"] = new SelectList( await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
            //    .Where(x => x.EmployerSupervisorId == id && x.StudentSetUp.Suspended == false), "Id", "Name");
            EmployerSupervisor = await _context.EmployerSupervisors.Where(x => x.Id == id).SingleOrDefaultAsync();
            Scafs = await _context.Scafs.Include(x => x.StudentSetUp).Include(x => x.EmployerSupervisor)
                .Where(x => x.EmployerSupervisorId == id && x.StudentSetUp.Suspended == false).ToListAsync();
        }
    }
}