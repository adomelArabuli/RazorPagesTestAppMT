//using System.Web.Mvc;

//namespace FiltersTestProject.Filters
//{
//	public class AdminAuthorizationFilter : FilterAttribute, IAuthorizationFilter
//	{
//		public void OnAuthorization(AuthorizationContext filterContext)
//		{
//			if(!filterContext.HttpContext.User.Identity.IsAuthenticated)
//			{
//				filterContext.Result = new HttpUnauthorizedResult();
//			}
//			else if (!filterContext.HttpContext.User.IsInRole("Admin"))
//			{
//				filterContext.Result = new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
//			}
//		}
//	}
//}
