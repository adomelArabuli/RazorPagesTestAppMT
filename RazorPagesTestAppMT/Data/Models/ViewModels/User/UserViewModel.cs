namespace RazorPagesTestAppMT.Data.Models.ViewModels.User
{
	public class UserViewModel
	{
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
