using ClincApi.Models;
using ClinicFront.Services;
using ClinicModels.DTOs.MainDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ClinicFront.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;

        public LoginModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager , IUserService userService )
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._userService = userService;
        }
        public int MyProperty { get; set; }
        [BindProperty]
        public InputModal Input { get; set; }
  
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/mainpageadmin");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Get the user by their username (you may need to customize this depending on your user store)
                    var user = await _userManager.FindByNameAsync(Input.UserName);

                    // Check if the user exists and has roles
                    if (user != null )
                    {
                        var claimsIdentity = new ClaimsIdentity();
                        // Retrieve the user's roles
                        var userRoles = await _userManager.GetRolesAsync(user);

                        // Create claims for email and roles
                        var rolesClaim = new Claim(ClaimTypes.Role, string.Join(",", userRoles));
                        if (user.Email != null)
                        {
                            var emailClaim = new Claim(ClaimTypes.Email, user.Email);
                            // Create a new ClaimsIdentity with the claims
                            claimsIdentity = new ClaimsIdentity(new[]
                            {
                            new Claim(ClaimTypes.Name, user.UserName),  // You can add the username as well
                            emailClaim,
                            rolesClaim
                            }, IdentityConstants.ApplicationScheme);
                        }
                        else
                        {
                            // Create a new ClaimsIdentity with the claims
                            claimsIdentity = new ClaimsIdentity(new[]
                            {
                            new Claim(ClaimTypes.Name, user.UserName),  // You can add the username as well
                            rolesClaim
                            }, IdentityConstants.ApplicationScheme);
                        }
                       
                        // Sign in the user with the custom claims
                            await HttpContext.SignInAsync(
                            IdentityConstants.ApplicationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            new AuthenticationProperties { IsPersistent = false }
                        );
                    }

                    return LocalRedirect(ReturnUrl);
                }
            }
            return Page();

        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    ReturnUrl = Url.Content("~/");
        //    if (ModelState.IsValid)
        //    {
        //        LoginDTO loginDTO = new LoginDTO()
        //        {
        //            UserName = Input.UserName,
        //            Password = Input.Password
        //        };

        //     var result =   await _userService.Login(loginDTO);
        //        if (result)
        //        {
        //            return LocalRedirect(ReturnUrl);
        //        }
        //    }
        //    return Page();

        //}
        public class InputModal
        {
            [Required(ErrorMessage = "Email is required")]
            
            public string UserName { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
