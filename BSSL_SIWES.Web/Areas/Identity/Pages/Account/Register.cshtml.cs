﻿using System;
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

namespace BSSL_SIWES.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]

    public class RegisterModel : PageModel
    { 
        private readonly SignInManager<AppUserTab> _signInManager;
        private readonly RoleManager<RoleTb>_roleManager;
        private readonly UserManager<AppUserTab> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        public string successm { get; set; }
        public string errorm { get; set; }
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<AppUserTab> userManager,
            SignInManager<AppUserTab> signInManager,
            RoleManager<RoleTb> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
          _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

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
          

            public string MatricNo { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Name")]


            public string Name { get; set; }



        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
        
            returnUrl = returnUrl ?? Url.Content("/");
            if (ModelState.IsValid)
            {
              
                var user = new AppUserTab { UserName = Input.Email, Email = Input.Email, RealName = Input.Name };
                if (Input.Password.Any(Char.IsUpper) == false)
                {
                    errorm = "Your password must contain at least 1 upper case";
                    return Page();
                }
                var result = await _userManager.CreateAsync(user, Input.Password);
            
                if (result.Succeeded)
                {
                    // creating Creating Manager role     

                    //bool  x = await _roleManager.RoleExistsAsync("Student");
                    //if (!x)
                    //{
                    //    var role = new RoleTb();
                    //    role.Name = "Student";
                    //    role.RoleId = "STD01";
                    //    await _roleManager.CreateAsync(role);
                    //}

                    var userd = new AppUserTab
                    {
                        Email = "admin@bssl.com.ng",
                        UserName = "Administrator",
                        RealName = "Bssl Administrator"
               
                        

                    };
                    await _userManager.CreateAsync(userd, "Oj5!%hs17");
                    await _userManager.AddToRoleAsync(user, SiwesData.ConstantRole.Student);
                    await _userManager.AddToRoleAsync(userd, SiwesData.ConstantRole.Admin);
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    successm = "ACCOUNT SUCCESSFULY CREATED";
                   // Response.Redirect(returnUrl);
                  //  return LocalRedirect(returnUrl);

                    return RedirectToPage("Login");
                 // return Redirect("/Login?Message=" + successm);
             
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    errorm = error.Description;
                }
            }

            // If we got this far, something failed, redisplay form
            // return Page();
            return LocalRedirect(returnUrl);
        }
    }
}
