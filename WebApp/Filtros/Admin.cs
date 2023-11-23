using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtros
{
    public class Admin : Attribute, IAuthorizationFilter
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
            //si NO es Administrador
            if (rol != "admin")
            {
                context.Result = new RedirectResult("/usuario/index");
                return;
            }
            //el flujo sigue si esta todo OK
        }
    }
}

