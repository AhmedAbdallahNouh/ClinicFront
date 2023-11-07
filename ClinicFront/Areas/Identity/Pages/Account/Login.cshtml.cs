using ClincApi.Models;
using ClinicFront.Services;
using ClinicModels.DTOs.MainDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;

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
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Get the user by their username (you may need to customize this depending on your user store)
                    var user = await _userManager.FindByNameAsync(Input.UserName);
                    if(user != null)
                    {
                        var userrole = await _userManager.GetRolesAsync(user);
                        //if (userrole[0] == "Doctor")
                        //{
                        //}

                    }
                    // Check if the user exists and has roles
                    if (user != null )
                    {
                        var claimsIdentity = new ClaimsIdentity();
                        // Retrieve the user's roles
                        var userRoles = await _userManager.GetRolesAsync(user);

                        // Create claims 
                        var IdClaim = new Claim(ClaimTypes.NameIdentifier, user.Id);
                        var rolesClaim = new Claim(ClaimTypes.Role, string.Join(",", userRoles));
                        List<Claim> claims = new List<Claim>();
                        claims.Add(IdClaim);
                        claims.Add(rolesClaim);
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));

                        if (user.Email != null) claims.Add(new Claim(ClaimTypes.Email, user.Email));
                        if (!string.IsNullOrEmpty(user.FirstName) || !string.IsNullOrEmpty(user.LastName) ) 
                            claims.Add(new Claim("Name", $"{(user.FirstName != null ? user.FirstName : string.Empty)} {(user.LastName != null ? user.LastName : string.Empty )} "));

                        if (!string.IsNullOrEmpty(user.Image))
                        {
                            claims.Add(new Claim("Image", user.Image));
                        }
                        else
                        {
                            claims.Add(new Claim("Image", "https://upload.wikimedia.org/wikipedia/commons/c/cc/Ismaily_SC_logo.png"));
                        }
                        // Create a new ClaimsIdentity with the claims
                        claimsIdentity = new ClaimsIdentity(claims ,IdentityConstants.ApplicationScheme);

                        // Sign in the user with the custom claims
                        await HttpContext.SignInAsync(
                            IdentityConstants.ApplicationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddDays(15)});
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
