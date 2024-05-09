using FiltersTestProject.Filters;
using FiltersTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersTestProject.Controllers
{
	[ExceptionHandlingFilter]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public ActionResult Index()
		{
			throw new Exception("An error occured test");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}