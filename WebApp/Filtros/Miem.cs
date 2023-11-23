using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Miem : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");

            //no loguado
            if (string.IsNullOrEmpty(rol))
            {
                context.Result = new RedirectResult("/usuario/index");
                return;
            }
            //si NO es Miembro
            if (rol != "miem")
            {
                context.Result = new RedirectResult("/usuario/index");
                return;
            }
            //el flujo sigue si esta todo OK
        }
    }
}

