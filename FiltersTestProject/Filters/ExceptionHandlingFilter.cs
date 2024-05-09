using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Mvc;

namespace FiltersTestProject.Filters
{
	public class ExceptionHandlingFilter : FilterAttribute,IFilterMetadata, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    {
		public void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
		{
			context.Result = new Microsoft.AspNetCore.Mvc.ViewResult { ViewName = "Error"};
		}
	}
}
	
