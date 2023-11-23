using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1
{

    public abstract class Publicacion : IEquatable<Publicacion>
    {
        //Static
        private static int autID;

        //Datos
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public Miembro Miembro { get; set; }
        public string Titulo { get; set; }
        public bool EsPublico { get; set; }
        public int CdadLike { get; set; }
        public int CdadDislike { get; set; }
        public decimal VA { get; set; }


        public Publicacion()
        {

        }

        //Constructor
        public Publicacion(string contenido, DateTime fecha, Miembro miembro, string titulo, bool esPublico)
        {
            Id = ++autID;
            Contenido = contenido;
            Fecha = fecha;
            Miembro = miembro;
            Titulo = titulo;
            EsPublico = esPublico;
            Validar();
            CdadLike = 0;
            CdadDislike = 0;
            VA = 0;
        }

        /// <summary>
        ///     Esta funcion llama a los validar Contenido y Titulo
        /// </summary>
        public void Validar()
        {
            ValidarContenido(Contenido);
            ValidarTitulo(Titulo);
        }

        public bool Equals(Publicacion other)
        {
            return other != null && Id == other.Id;
        }

        /// <summary>
        ///     Esta funcion verifica que el contenido no sea vacio
        /// </summary>
        public static void ValidarContenido(string cont)
        {
            if (string.IsNullOrEmpty(cont))
            {
                throw new Exception("Contenido vacio");
            }
        }

        /// <summary>
        ///     Esta funcion verifica que el contenido no sea vacio y ademas tenga un largo mayor de 3
        /// </summary>
        public static void ValidarTitulo(string tit)
        {
            if (string.IsNullOrEmpty(tit) && tit.Length < 3)
            {
                throw new Exception("El título debe contener al menos 3 caracteres");
            }
        }


     

    }
}
