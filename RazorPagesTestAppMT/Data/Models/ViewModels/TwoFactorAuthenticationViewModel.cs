namespace RazorPagesTestAppMT.Data.Models.ViewModels
{
	public class TwoFactorAuthenticationViewModel
	{
        // Log in
        public string Code { get; set; }

        // Register
        public string Token { get; set; }
        public string? QRCodeUrl { get; set; }
    }
}
