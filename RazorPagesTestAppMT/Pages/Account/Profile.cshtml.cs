using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTestAppMT.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

		public ProfileModel(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                ViewData["TwoFactorEnabled"] = false;
            }
            else
            {
				ViewData["TwoFactorEnabled"] = user.TwoFactorEnabled;
			}

            return Page();
        }
    }
}
