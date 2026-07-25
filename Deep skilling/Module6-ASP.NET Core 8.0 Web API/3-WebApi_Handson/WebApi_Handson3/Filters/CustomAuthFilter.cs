using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson3.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            ActionExecutingContext context)
        {
            bool allowAnonymous =
                context.ActionDescriptor.EndpointMetadata
                    .OfType<AllowAnonymousAttribute>()
                    .Any();

            if (allowAnonymous)
            {
                return;
            }

            string authorizationHeader =
                context.HttpContext.Request.Headers.Authorization
                    .FirstOrDefault() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(authorizationHeader))
            {
                context.Result = new BadRequestObjectResult(
                    "Invalid request - No Auth token"
                );

                return;
            }

            if (!authorizationHeader.Contains(
                    "Bearer",
                    StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new BadRequestObjectResult(
                    "Invalid request - Token present but Bearer unavailable"
                );

                return;
            }

            base.OnActionExecuting(context);
        }
    }
}