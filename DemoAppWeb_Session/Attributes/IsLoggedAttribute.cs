using DemoAppWeb_Session.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoAppWeb_Session.Attributes
{
    public class IsLoggedAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // if je ne suis connecté
            if(!context.HttpContext.Session.IsAuthenticated())
            {
                //rediriger vers la page de login
                context.Result = new RedirectToRouteResult(
                    new { Controller = "Auth", Action = "Login" }
                );
                return;
            }

            // sinon ne rien faire
        }
    }
}
