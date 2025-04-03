using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

public class RegisterModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;
    private readonly IEmailSender _emailSender;

    public RegisterModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context, IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _context = context;
        _emailSender = emailSender;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }

    public async Task OnGetAsync(string returnUrl = null)
    {
        ReturnUrl = returnUrl;
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    //public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    //{
    //    returnUrl ??= Url.Content("~/");
    //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

    //    if (ModelState.IsValid)
    //    {
    //        var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
    //        var result = await _userManager.CreateAsync(user, Input.Password);
    //        if (result.Succeeded)
    //        {
    //            await _userManager.AddToRoleAsync(user, Input.Role);
    //            await _signInManager.SignInAsync(user, isPersistent: false);
    //            // Create and save the Profile
    //            var profile = new Profile
    //            {
    //                UserId = user.Id,
    //                Email = user.Email,
    //                Role = Input.Role,
    //                CreatedAt = DateTime.UtcNow,
    //                UpdatedAt = DateTime.UtcNow
    //            };

    //            _context.Profiles.Add(profile);
    //            await _context.SaveChangesAsync();

    //            // Check the user's roles and redirect accordingly
    //            if (await _userManager.IsInRoleAsync(user, "Admin"))
    //            {
    //                return LocalRedirect(Url.Content("~/Admin"));
    //            }
    //            else if (await _userManager.IsInRoleAsync(user, "Customer"))
    //            {
    //                return LocalRedirect(Url.Content("~/"));
    //            }
    //            else if (await _userManager.IsInRoleAsync(user, "Provider"))
    //                return LocalRedirect(Url.Content("~/Provider"));
    //        }


    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError(string.Empty, error.Description);
    //        }
    //    }

    //    // If we got this far, something failed, redisplay form
    //    return Page();
    //}
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.AddToRoleAsync(user, Input.Role);
                await _signInManager.SignInAsync(user, isPersistent: false);
                // Create and save the Profile
                var profile = new Profile
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Role = Input.Role,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();

                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return Page();
    }

}