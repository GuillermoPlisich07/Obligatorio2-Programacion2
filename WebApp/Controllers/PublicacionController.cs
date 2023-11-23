using Microsoft.AspNetCore.Mvc;
using Obligatorio1;
using WebApp.Filtros;


namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string email)
        {
            ViewBag.Miembros = _sistema.ListarPost(email);
            return View();
        }

        public IActionResult VistaPublicar()
        {
            return View();
        }

        public IActionResult BuscarPost()
        {
            return View();
        }

        public IActionResult EncontrarPost()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Postear(string titulo, string contenido, string img, string estado)
        {

            string email = HttpContext.Session.GetString("email");
            string rol = HttpContext.Session.GetString("rol");

            Miembro miembro = _sistema.ObtenerMiembro(email);
            bool esPublico = false;
            if (estado=="publico")
            {
                esPublico = true;
            }
            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Now;

            Post post5 = new Post(contenido, fechaActual, miembro, titulo, img, estado, false, esPublico, 0, 0, 0);
            _sistema.CrearNuevoPost(post5);

            return RedirectToAction("Saludo", "Usuario");
        }

        [HttpPost]
        public IActionResult Comentar(string titulo, string objetoComentario, string comentario)
        {
            string email = HttpContext.Session.GetString("email");
            string rol = HttpContext.Session.GetString("rol");

            Post unPost = (Post)_sistema.ObtenerPublicacion(objetoComentario);
            Miembro miembro = _sistema.ObtenerMiembro(email);
            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Now;

            Comentario nuevoComentario = new Comentario(unPost, comentario, fechaActual, miembro, titulo, unPost.EsPublico, 0, 0, 0);
            _sistema.CrearNuevoComentario(nuevoComentario);
            unPost.AsociarComentario(nuevoComentario);

            return RedirectToAction("Saludo", "Usuario");
        }
    }
}
