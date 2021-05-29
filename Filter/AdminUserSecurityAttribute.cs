using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebProject.Filter
{
    public class AdminUserSecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("AdminRole") == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}