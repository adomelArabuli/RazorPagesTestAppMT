using FiltersTestProject.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersTestProject.Controllers
{
	[ExceptionHandlingFilter]
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			throw new Exception("An error occured");
		}
	}
}
