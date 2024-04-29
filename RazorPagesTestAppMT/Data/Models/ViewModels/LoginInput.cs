using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTestAppMT.Data.Models.ViewModels
{
	public class LoginInput
	{
		[Required]
		[EmailAddress]
        public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
