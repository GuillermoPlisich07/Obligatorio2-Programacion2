﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Obligatorio1;
using WebApp.Filtros;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;


        public IActionResult Index()
        {
            string email = HttpContext.Session.GetString("email");
            string rol = HttpContext.Session.GetString("rol");

            if (email != null)
            {
                return RedirectToAction("Saludo");
            }

            return View();
        }

        public IActionResult Saludo()
        {
            string email = HttpContext.Session.GetString("email");
            // Obtengo el nombre de usuario desde el correo electrónico
            string nombreUsuario = email.Split('@')[0];
            string rol = HttpContext.Session.GetString("rol");

            Miembro unMiem = _sistema.ObtenerMiembro(email);

            // Paso el nombre de usuario a la vista
            ViewData["NombreUsuario"] = nombreUsuario;

            if (rol != null && rol == "miem")
            {
                List<Post> ListPublicacion = _sistema.ListarTodasLosPost();

                if (ListPublicacion.Count != 0)
                {
                    List<Comentario> comentarios = new List<Comentario>();

                    List<Post> post = new List<Post>();

                    foreach (Post unPost in ListPublicacion)
                    {
                        if (unPost.Miembro.Bloqueado== false && unPost.Censurado==false)
                        {
                            if (unMiem == unPost.Miembro)
                            {
                                post.Add(unPost);
                                List<Comentario> comenPostAmigo = unPost.ListaDeComentarios();

                                foreach (Comentario unCom in comenPostAmigo)
                                {
                                    comentarios.Add(unCom);
                                }
                            }
                            else if (unPost.Estado == "privado" && _sistema.SonAmigos(unMiem, unPost.Miembro))
                            {
                                post.Add(unPost);
                                List<Comentario> comenPostAmigo = unPost.ListaDeComentarios();

                                foreach (Comentario unCom in comenPostAmigo)
                                {
                                    comentarios.Add(unCom);
                                }
                            }
                            else
                            {
                                post.Add(unPost);
                                List<Comentario> comenPostAmigo = unPost.ListaDeComentarios();

                                foreach (Comentario unCom in comenPostAmigo)
                                {
                                    comentarios.Add(unCom);
                                }
                            }
                        }
                        
                    }
                    ViewData["Posts"] = post;

                    ViewData["Comentarios"] = comentarios;

                }
                else
                {
                    ViewData["Posts"] = null;

                    ViewData["Comentarios"] = null;
                }

                //Miembro unMiem = _sistema.ObtenerMiembro(email);
                //if (unMiem != null)
                //{

                //    List<Miembro> amigos = unMiem.ObtenerAmigos();

                //    List<Comentario> comentarios = new List<Comentario>();

                //    List<Post> postsAmigos = new List<Post>();

                //    foreach (Miembro unAmi in amigos)
                //    {

                //        List<Post> posts = _sistema.ListarPostDelMiembro(unAmi.Email);

                //        foreach (Post unPost in posts)
                //        {
                //            postsAmigos.Add(unPost);
                //            List<Comentario> comenPostAmigo = unPost.ListaDeComentarios();

                //            foreach (Comentario unCom in comenPostAmigo)
                //            {
                //                comentarios.Add(unCom);
                //            }
                //        }

                //    }

                //    ViewData["Posts"] = postsAmigos;

                //    ViewData["Comentarios"] = comentarios;
                //}
                //else
                //{
                //    ViewData["Posts"] = null;

                //    ViewData["Comentarios"] = null;
                //}
            }
            else
            {
                ViewData["Posts"] = null;

                ViewData["Comentarios"] = null;
            }

            return View();
        }



        [Admin]
        public IActionResult ListarMiembros()
        {
            ViewBag.Miembros = _sistema.ListarMiembros();
            return View();
        }


        public IActionResult Login(string email, string password)
        {
            Usuario unUsu = _sistema.ObtenerUsuario(email, password);
            if (unUsu == null)
            {
                return RedirectToAction("index");
            }

            string rol = "";
            // Roles validos son admin / miem 
            if (unUsu.IsAdmin)
            {
                rol = "admin";
            }
            else if (!unUsu.IsAdmin)
            {
                rol = "miem";
            }

            // guardo los datos del usuario logueado
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("rol", rol);

            /*
             * if (rol == "admin")
            {
                return Redirect("/administrador");
            }
            else if (rol == "miem")
            {
                return Redirect("/miembro");
            }
            */
            return RedirectToAction("index");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }


        //muestra el formulario
        public IActionResult CreateMiembro()
        {
            return View();        //Esto garantiza que siempre haya un objeto Miembro en el modelo cuando la vista se renderice
        }


        [HttpPost]
        public IActionResult CrearMiembro(string email,string password, string nombre,
            string apellido, string fechaNacimiento)
        {

            try
            {
                DateTime fechaNac = DateTime.Parse(fechaNacimiento);
                Miembro nuevo = new Miembro(email,password,false,nombre,apellido,fechaNac);
                _sistema.CrearNuevoMiembro(nuevo);
                return RedirectToAction("index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View("index");
        }


        //Bloquear y activar un miembro
        [Admin]
        [HttpPost]
        public IActionResult BloquearMiembro(string email)     //tiene que ser el name de la vista
        {
            Miembro miembroABloquear = _sistema.ObtenerMiembro(email);

            if (miembroABloquear != null && !miembroABloquear.Bloqueado)
            {
                miembroABloquear.Bloqueado = true;
            }

            // Actualiza la página después de enviar la solicitud
            return RedirectToAction("ListarMiembros");
        }

        [Admin]
        [HttpPost]
        public IActionResult ActivarMiembro(string email)     //tiene que ser el name de la vista
        {
            Miembro miembroAactivar = _sistema.ObtenerMiembro(email);
            if (miembroAactivar != null && miembroAactivar.Bloqueado)
            {
                miembroAactivar.Bloqueado = false;
            }

            // Actualiza la página después de enviar la solicitud
            return RedirectToAction("ListarMiembros");
        }

        [Miem]
        public IActionResult VisualizarPublicacionesParaMiembro()
        {
            string email = HttpContext.Session.GetString("email");
            ViewData["Email"] = email;
            string rol = HttpContext.Session.GetString("rol");

            //Miembro unMiem = _sistema.ObtenerMiembro(email);

            return View();
        }

        [Miem]
        public IActionResult ListarMiembrosParaSolicitudAmistad()
        {
            string email = HttpContext.Session.GetString("email");
            ViewData["Email"] = email;
            string rol = HttpContext.Session.GetString("rol");
            //ViewBag es un objeto dinámico q se utiliza para pasar datos desde el controlador a la vista
            ViewBag.Miembros = _sistema.ListarMiembrosParaSolicitudAmistad(email);
            Miembro miembro = _sistema.ObtenerMiembro(email);
            ViewBag.Invitaciones = _sistema.ObtenerInvitacionesParaUnMiembro(miembro);
            return View();
        }

        [Miem]
        [HttpPost]
        public IActionResult EnviarSolicitudAmistad(string emailAmigo)
        {
            string emailSolicitante = HttpContext.Session.GetString("email");

            Miembro miembroSolicitante = _sistema.ObtenerMiembro(emailSolicitante);
            Miembro miembroSolicitado = _sistema.ObtenerMiembro(emailAmigo);

            if (miembroSolicitante != null && miembroSolicitado != null)
            {
                Invitacion invitacion = new Invitacion(miembroSolicitado, miembroSolicitante, "proceso", DateTime.Now);
                _sistema.CrearNuevaInvitacion(invitacion);
            }

            // Actualiza la página después de enviar la solicitud
            return RedirectToAction("ListarMiembrosParaSolicitudAmistad");
        }

        [Miem]
        [HttpPost]
        public IActionResult AceptarSolicitudAmistad(string IDInvitacion)   //tiene que ser el name de la vista
        {
            int idInvita = int.Parse(IDInvitacion);
            Invitacion unaInvita = _sistema.ObtenerInvitacionPorID(idInvita);
            if (IDInvitacion != null)
            {
                _sistema.AgregarAmigoSistema(unaInvita);
            }
            // Actualiza la página
            return RedirectToAction("ListarMiembrosParaSolicitudAmistad");
        }

        [Miem]
        [HttpPost]
        public IActionResult RechazarSolicitudAmistad(string IDInvitacion)  
        {
            int idInvita = int.Parse(IDInvitacion);
            Invitacion unaInvita = _sistema.ObtenerInvitacionPorID(idInvita);
            if (IDInvitacion != null)
            {
                _sistema.RechazarInvitacionSistema(unaInvita);
            }
            //Actualiza la página
            return RedirectToAction("ListarMiembrosParaSolicitudAmistad");
        }

        






    }


}