using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTestAppMT.Data.Models;
using RazorPagesTestAppMT.Data.Models.ViewModels.User;

namespace RazorPagesTestAppMT.Pages.User
{
    public class GetUsersModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
		public GetUsersModel(ApplicationDbContext db, UserManager<IdentityUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}

        public List<UserViewModel> Users = new List<UserViewModel>();

		public async Task<IActionResult> OnGetAsync()
        {
            var users = await _db.Users.ToListAsync();
            var roles = await _db.Roles.ToListAsync();
            var userRoles = await _db.UserRoles.ToListAsync();

            foreach (var user in users)
            {
                var userVm = new UserViewModel();

                var userRole = userRoles.FirstOrDefault(u => u.UserId == user.Id);

                userVm.Id = user.Id;
                userVm.UserName = user.UserName;
                userVm.Role = roles.FirstOrDefault(r => r.Id == userRole.RoleId).Name;
                userVm.EmailConfirmed = user.EmailConfirmed;
                userVm.TwoFactorEnabled = user.TwoFactorEnabled;
                userVm.LockoutEnd = user.LockoutEnd;

                Users.Add(userVm);
            }
            return Page();
        }
    }
}
