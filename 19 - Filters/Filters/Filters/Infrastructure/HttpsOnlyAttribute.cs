using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Filters.Infrastructure
{
    // [Authorize] attribute isn't a filter any more and it doesn't implement IAuthorizationFilter interface, a global attribute 
    // is used instead to detect [Authorized] attributes to enforce policies defined by ASP.NET Core indentity system
    public class HttpsOnlyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
            {
                context.Result =
                    new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}