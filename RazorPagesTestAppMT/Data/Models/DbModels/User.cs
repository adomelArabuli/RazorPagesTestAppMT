using Microsoft.AspNetCore.Identity;

namespace RazorPagesTestAppMT.Data.Models.DbModels
{
	public class ApplicationUser : IdentityUser
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
