using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SiwesData.Setup;
using SiwesData;
using Microsoft.AspNetCore.Mvc.Rendering;
using BSSL_SIWES.Web.Areas.Identity.Pages.Account;
using Microsoft.EntityFrameworkCore;

namespace BSSL_SIWES.Web.Pages.Account
{ 
    [AllowAnonymous]

    public class CreateSchCord : PageModel
    {
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<RoleTb> _roleManager;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        public string successm { get; set; }
        public string errorm { get; set; }
        private readonly IEmailSender _emailSender;

        public CreateSchCord(
            UserManager<AppUserTab> userManager,
            SignInManager<AppUserTab> signInManager,
            RoleManager<RoleTb> roleManager,
            ILogger<RegisterModel> logger,
            ApplicationDbContext context,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _context = context;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public RoleTb RoleTb {get;set;}
        public IList<SiwesData.Setup.Institution> Listofinst { get; set; }
        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "Please  email address is compulsory")]
            [EmailAddress]
            [Display(Name = "Email")]


         
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

            public string ConfirmPassword { get; set; }

            //[Required]
            //[StringLength(100, ErrorMessage = "Matric No is required")]
            //[DataType(DataType.Text)]
            //[Display(Name = "Matric Number")]
        
            [Required]
            [StringLength(100, ErrorMessage = "Please select Role/Gruop")]
            public string RoleId { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "Please enter Staff Id")]
            public string Sfaffid { get; set; }


            [DataType(DataType.Text)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            public string RoleName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Please  enter institution")]
            public string InstName { get; set; }
            public string InstId { get; set; }

        }

        //public void OnGet(string returnUrl = null)
        //{
        //    ReturnUrl = returnUrl;
        //}
        public async Task OnGetAsync( string instid)
        {
            //  ViewData["RoleGrp"] =  new SelectList(_context.RoleTb, "RoleId", "Name");
            //id = 2;
            #region get if log in perseon its from institution
            if (_signInManager.IsSignedIn(User))
            {
                var getuser = await _userManager.GetUserAsync(User);

                var usercord = await _context.InstitutionOfficers.FirstOrDefaultAsync(x => x.Email == getuser.Email.ToString());

                #endregion
                if (usercord == null)
                    Listofinst = await _context.Institution.Where(x => x.Deactivate == "0" || x.Deactivate == null).ToListAsync();
                else
                {
                    Listofinst = await _context.Institution.Where(x => (x.Deactivate == "0" || x.Deactivate == null)
                    && x.Id == usercord.InstitutionId).ToListAsync();

                    if (Listofinst.Count == 1)
                    {
                        foreach (var dd in Listofinst)
                        {
                           // Input.InstName = dd.Name.ToString().Trim();
                           //  Input.InstId = dd.Id.ToString().Trim();
                        }
                           
                     }
                }
            }
            else
            {

            }

        }
         
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
        
            returnUrl = returnUrl ?? Url.Content("/");
            //if (ModelState.IsValid)
            //{
              
            var user = new AppUserTab { UserName = Input.Email, Email = Input.Email, RealName= Input.Name, EmpRcNo = Input.InstId };
            //bool x = await _roleManager.RoleExistsAsync("Cordinator");
            //if (!x)
            //{
            //    var role = new RoleTb();
            //    role.Name = "Cordinator";
            //    role.RoleId = "Cord001";
            //    await _roleManager.CreateAsync(role);
            //}
            //await _userManager.AddToRoleAsync(user, "Student");
            if (Input.Password.Any(Char.IsUpper) == false)
                {
                    errorm = "Your password must contain at least 1 upper case";
                    return Page();
                }
                var useremail = await _userManager.FindByEmailAsync(Input.Email);

                if (useremail != null)
                {
                    errorm = "Cordinator already exist please check ";
                    return Page();
                }

                var result = await _userManager.CreateAsync(user, Input.Password);
            
                if (result.Succeeded)
                {
                   
                    await _userManager.AddToRoleAsync(user,ConstantRole.Cordinator);
                    _logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    successm = "ACCOUNT SUCCESSFULY CREATED";
                    // Response.Redirect(returnUrl);
                    //  return LocalRedirect(returnUrl);
                    return Page();
                  //  return RedirectToPage("Login");
                 // return Redirect("/Login?Message=" + successm);
             
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorm = error.Description;
                }
          //  }

            // If we got this far, something failed, redisplay form
             return Page();
         //   return LocalRedirect(returnUrl);
        }
    }
}
