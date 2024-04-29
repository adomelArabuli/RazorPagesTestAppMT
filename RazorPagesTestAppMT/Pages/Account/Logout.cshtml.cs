using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTestAppMT.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string returUrl = null)
        {
            await _signInManager.SignOutAsync();

            if(returUrl != null)
            {
                return LocalRedirect(returUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
