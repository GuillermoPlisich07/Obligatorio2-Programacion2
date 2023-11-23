using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    public class Post:Publicacion
    {
        public string Img { get; set; }

        public string Estado { get; set; }

        private List<Comentario> _listaComentarios = new List<Comentario>();

        public bool Censurado { get; set; }

        public Post() : base()
        {

        }

        public Post(string contenido, DateTime fecha, Miembro miembro, string titulo,string img, 
            string estado, bool censurado, bool esPublico)
        :base(contenido,fecha,miembro,titulo,esPublico)
        {
            Img = img;
            Estado = estado;
            Censurado = censurado;
            ValidarPost();
        }

        /// <summary>
        ///     Devuelve la Lista de Comentarios del post
        /// </summary>
        /// <returns>Se retorna una lista></returns>
        public List<Comentario> ListaDeComentarios()
        {
            return _listaComentarios;
        }

        /// <summary>
        ///  Asocia el comentario a la lista del  Post
        /// </summary>
        public void AsociarComentario(Comentario comentario)
        {
            _listaComentarios.Add(comentario);
        }


        /// <summary>
        ///     Esta funcion llama al validar de la clase padre, ademas valida que el campo imagen sea valido
        /// </summary>
        public void ValidarPost()
        {
            base.Validar();
            ValidarImagen(Img);
        }

        /// <summary>
        ///     Esta funcion realizar una validacion de la imagen la cual no puede ser vacia y ademas que tiene que terminar
        ///     con .png o .jpg
        /// </summary>
        public static void ValidarImagen(string img)
        {
            if (string.IsNullOrEmpty(img))
            {
                throw new Exception("Imagen vacia");
            }

            string imgMin = img.ToLower();
            if (!imgMin.EndsWith(".jpg") && !imgMin.EndsWith(".png") )
            {
                throw new Exception("Formato de imagen no valido");
            }

        }

    
    }
}
