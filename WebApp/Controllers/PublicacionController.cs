using Microsoft.AspNetCore.Mvc;
using Obligatorio1;
using WebApp.Filtros;


namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [Admin]
        public IActionResult Index()
        {
            ViewData["Posts"] = _sistema.ListarTodasLosPost();
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

        [Miem]
        [HttpPost]
        public IActionResult Postear(string titulo, string contenido, string img, string estado)
        {

            string email = HttpContext.Session.GetString("email");
            string rol = HttpContext.Session.GetString("rol");

            try
            {
                Miembro miembro = _sistema.ObtenerMiembro(email);
                if (miembro.Bloqueado==false)
                {
                    if (titulo!=null)
                    {
                        if (contenido!=null)
                        {
                            if (img!=null)
                            {
                                if (estado!=null)
                                {
                                    bool esPublico = false;
                                    if (estado == "publico")
                                    {
                                        esPublico = true;
                                    }
                                    DateTime fechaActual = new DateTime();
                                    fechaActual = DateTime.Now;

                                    Post post5 = new Post(contenido, fechaActual, miembro, titulo, img, estado, false, esPublico);
                                    _sistema.CrearNuevoPost(post5);

                                    return RedirectToAction("Saludo", "Usuario");
                                }
                                else
                                {
                                    throw new Exception($"El estado es requerido");
                                }
                            }
                            else
                            {
                                throw new Exception($"La imagen es requerido");
                            }
                        }
                        else
                        {
                            throw new Exception($"El contenido es requerido");
                        }
                    }
                    else
                    {
                        throw new Exception($"El titulo es requerido");
                    }
                }
                else
                {
                    throw new Exception($"No se puede realizar posteos tiene la cuenta bloqueada");
                }
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View("VistaPublicar");
            }
        }

        [Miem]
        [HttpPost]
        public IActionResult Comentar(string titulo, string objetoComentario, string comentario)
        {
            string email = HttpContext.Session.GetString("email");
            string rol = HttpContext.Session.GetString("rol");

            Miembro miembro = _sistema.ObtenerMiembro(email);
            try
            {
                if (miembro.Bloqueado==false)
                {
                    if (objetoComentario != null)
                    {
                        if (titulo != null)
                        {
                            if (comentario != null)
                            {
                                Post unPost = (Post)_sistema.ObtenerPublicacion(objetoComentario);
                                DateTime fechaActual = new DateTime();
                                fechaActual = DateTime.Now;

                                Comentario nuevoComentario = new Comentario(unPost, comentario, fechaActual, miembro, titulo, unPost.EsPublico);
                                _sistema.CrearNuevoComentario(nuevoComentario);
                                unPost.AsociarComentario(nuevoComentario);

                                return RedirectToAction("Saludo", "Usuario");
                            }
                            else
                            {
                                throw new Exception($"El comentario es requerido");
                            }
                        }
                        else
                        {
                            throw new Exception($"El titulo es requerido");
                        }
                    }
                    else
                    {
                        throw new Exception($"El objeto Post no esta referenciado");
                    }
                }
                else
                {
                    throw new Exception($"No se puede realizar comentarios tiene la cuenta bloqueada");
                }
            }catch (Exception e)
            {
                return RedirectToAction("Saludo", "Usuario", new{ error= e.Message});
            }
        }

        [Admin]
        [HttpPost]
        public IActionResult Bloquear(string id)
        {
            try
            {
                if (id!=null)
                {
                    Post unPost = (Post)_sistema.ObtenerPublicacion(id);
                    unPost.Censurado = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception($"El objeto Post es requerido");
                }
            }
            catch (Exception e)
            {

                ViewBag.error = e.Message;
                return View("Index");
            }

        }

        [Admin]
        [HttpPost]
        public IActionResult Desbloquear(string id)
        {

            try
            {
                if (id != null)
                {
                    Post unPost = (Post)_sistema.ObtenerPublicacion(id);
                    unPost.Censurado = false;
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception($"El objeto Post es requerido");
                }
            }
            catch (Exception e)
            {

                ViewBag.error = e.Message;
                return View("Index");
            }
            
        }

    }
}
