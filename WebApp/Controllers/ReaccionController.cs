using Microsoft.AspNetCore.Mvc;
using Obligatorio1;

namespace WebApp.Controllers
{
    public class ReaccionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reaccionar(string objetoPost, string tipoReaccion)
        {
            string email = HttpContext.Session.GetString("email");
            string rol = HttpContext.Session.GetString("rol");

            Publicacion unPub = _sistema.ObtenerPublicacion(objetoPost);
            Miembro miembro = _sistema.ObtenerMiembro(email);
            Reaccion reaccion = _sistema.BuscarReaccion(unPub, miembro);

            if (reaccion == null)
            {
                Reaccion nueva = new Reaccion(tipoReaccion, miembro, unPub);
                _sistema.CrearNuevaReaccion(nueva);

                return RedirectToAction("Saludo", "Usuario");
            }
            else
            {
                if (reaccion.TipoReaccion=="like")
                {
                    if (reaccion.TipoReaccion == tipoReaccion)
                    {
                        return RedirectToAction("Saludo", "Usuario");
                    }
                    else
                    {
                        reaccion.TipoReaccion = "dislike";
                        return RedirectToAction("Saludo", "Usuario");
                    }
                }
                else if (reaccion.TipoReaccion == "dislike")
                {
                    if (reaccion.TipoReaccion == tipoReaccion)
                    {
                        return RedirectToAction("Saludo", "Usuario");
                    }
                    else
                    {
                        reaccion.TipoReaccion = "like";
                        return RedirectToAction("Saludo", "Usuario");
                    }
                }
            }
            return RedirectToAction("Saludo", "Usuario");
        }
    }
}
