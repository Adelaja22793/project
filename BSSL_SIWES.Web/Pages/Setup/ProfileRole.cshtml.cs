using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiwesData.Setup;

namespace BSSL_SIWES.Web
{

    public class ProfileRoleModel : PageModel
    {
        private readonly SiwesData.ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ProfileRoleModel(SiwesData.ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public List<RoleTb> RoleTbs { get; set; }
        [BindProperty]
        public RoleTb RoleTb { get; set; }

        public async Task OnGetAsync()
        {
            RoleTbs = await _context.RoleTb.ToListAsync();
            if (RoleTbs != null)
            {

            }
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!_context.RoleTb.Any(e => e.Id == RoleTb.Id))
        //    {
        //        _context.RoleTb.Add(RoleTb);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        var pos = await _context.RoleTb.FirstOrDefaultAsync(x => x.Id == RoleTb.Id);
        //        pos.Id = RoleTb.Id;
        //        pos.Name = RoleTb.Name;
               
        //        await _context.SaveChangesAsync();
        //    }


        //    ModelState.Clear();
        //    return Page();
        //    //    var emptyStudent = new RoleTb();

        //    //    if (await TryUpdateModelAsync<RoleTb>(
        //    //        emptyStudent,
        //    //        "student",   // Prefix for form value.
        //    //        s => s.Name))
        //    //    {
        //    //        _context.R.Add(emptyStudent);
        //    //        await _context.SaveChangesAsync();
        //    //        return RedirectToPage("./Index");
        //    //    }

        //    //    return Page();
        //    //}
        //}
    }
}
//public async Task<ActionResult<RoleTb>> PostRoleTb(RoleTb roleTb)
//{
//    var nameCheck = _context.RoleTbs
//                .Where(b => b.Name == roleTb.Name)
//                .FirstOrDefault();
//    if (nameCheck == null)
//    {
//        // save the item here
//        _context.RoleTbs.Add(roleTb);
//        await _context.SaveChangesAsync();
//    }
//    else
//    {
//        return Conflict("The item already exists");
//    }
    //_context.RoleTbs.Add(roleTb);
    //try
    //{
    //    await _context.SaveChangesAsync();
    //}
    //catch (DbUpdateException)
    //{
    //    if (RoleTbExists(roleTb.Name))
    //    {
    //        return Conflict("Item Already Exist");
    //    }
    //    else
    //    {
    //        throw;
    //    }
    //}

    //return CreatedAtAction("GetRoleTb", new { id = roleTb.Id }, roleTb);
//}