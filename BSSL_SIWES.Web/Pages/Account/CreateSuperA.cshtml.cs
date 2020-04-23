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

    public class CreateSuperA : PageModel
    {
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<RoleTb> _roleManager;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        public string successm { get; set; }
        public string errorm { get; set; }
        private readonly IEmailSender _emailSender;

        public CreateSuperA(
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
        public AgencySuperSetup Superv {get;set;}
        public List<SelectListItem> options { get; set; }
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
            options = await _context.AgencySuperSetup.Select(m => new SelectListItem
            {
                Value = m.Id.ToString().Trim(),
                Text = m.Name.Trim()
            }).ToListAsync();

        }
         
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
        
            returnUrl = returnUrl ?? Url.Content("/");
            //if (ModelState.IsValid)
            //{
              
            var user = new AppUserTab { UserName = Input.Email, Email = Input.Email, RealName= Input.Name, EmpRcNo = Input.InstId };
       
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
                   
                    await _userManager.AddToRoleAsync(user,ConstantRole.AgencySuper);
                    _logger.LogInformation("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    successm = "ACCOUNT SUCCESSFULY CREATED";
                
                    return Page();
              
             
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorm = error.Description;
                }
       
             return Page();
        
        }
    }
}
