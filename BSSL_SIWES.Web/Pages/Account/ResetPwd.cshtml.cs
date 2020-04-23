using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiwesData;
namespace BSSL_SIWES.Web.Pages.Account
{
    [AllowAnonymous]
    public class ResetPwdModel : PageModel
    {
        private readonly UserManager<AppUserTab> _userManager;

        public ResetPwdModel(UserManager<AppUserTab> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public string successm { get; set; }
        public string errorm { get; set; }
        public class InputModel
        {
            [Required]
          //  [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }

        public IActionResult OnGet(string code = null)
        {
            if (code == null)
            {
                //return BadRequest("A code must be supplied for password reset.");
                errorm = "A code must be supplied for password reset.";
            }
            else
            {
                Input = new InputModel
                {
                    Code = code
                };
                return Page();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.FindByEmailAsync(Input.Email);
            var user2 = await _userManager.FindByNameAsync(Input.Email);
            if (user == null && user2 == null)
            {
                // Don't reveal that the user does not exist
                // return RedirectToPage("./ResetPasswordConfirmation");
                errorm = " User name or email does not exist please check ";
                return Page();
            }

            var result = await _userManager.ResetPasswordAsync(user, "ACHJGKKDL08479LDIILLL", Input.Password);
           
            if (result.Succeeded)
            {
                successm = "ACCOUNT SUCCESSFULLY RESET ";
                return Page();
               // return RedirectToPage("./ResetPasswordConfirmation");
            }
            else
            {
             
                result = await _userManager.ResetPasswordAsync(user, "ACHJGKKDL08479LDIILLL", Input.Password);
                if (result.Succeeded)
                {
                    successm = "ACCOUNT SUCCESSFULLY RESET ";
                    return Page();
                    // return RedirectToPage("./ResetPasswordConfirmation");
                }
                else
                {
                    errorm = "RESETING OF ACCOUNT WAS NOT SUCCESFULL PLEASE AGAIN OR CONTACT ADMINISTARTOR ";
                  //  return Page();
                }
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
