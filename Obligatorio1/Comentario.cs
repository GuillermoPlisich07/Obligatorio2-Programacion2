using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{
    public class Comentario:Publicacion
    {
        public Post Post { get; set; }

        public Comentario(Post post, string contenido, DateTime fecha, Miembro miembro, string titulo, bool esPublico,
            int cdadLike, int cdadDislike, decimal vA)
        :base(contenido, fecha, miembro, titulo, esPublico, cdadLike, cdadDislike, vA)
        {
            Post = post;
            ValidarComentario();
        }

        /// <summary>
        ///     Llama validar del padre
        /// </summary>
        public void ValidarComentario()
        {
            base.Validar();
        }



    }
}
