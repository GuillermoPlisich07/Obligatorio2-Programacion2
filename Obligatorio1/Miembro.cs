using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio1
{
    public class Miembro:Usuario, IComparable<Miembro>
    {

        public string Nombre { get; set; }
        
        public string Apellido { get; set; }
        
        public DateTime FechaNac { get; set; }

        public bool Bloqueado { get;  set; }
        
        private List<Miembro> _listaAmigos = new List<Miembro>();

        
        //constructor vacio
        public Miembro() : base()
        {
        }

        public Miembro(string email, string password, bool isAdmin, string nombre, string apellido, DateTime fechaNac)
        :base(email,password,isAdmin)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNac = fechaNac;
            Bloqueado = false;
            ValidarMiembro();
        }

        public int CompareTo(Miembro other)
        {
            // Primero, compara por apellido
            int comparaApellido = this.Apellido.CompareTo(other.Apellido);
            // Si los apellidos son iguales, compara por nombre
            if (comparaApellido == 0)
            {
                return this.Nombre.CompareTo(other.Nombre);
            }

            return comparaApellido;
        }

        /// <summary>
        ///     Esta funcion verifica que los campso Nombre y Apellido no sean vacios, ademas de esto llama al verificar 
        ///     de la clase padre
        /// </summary>
        public void ValidarMiembro()
        {
            base.Validar();
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("El nombre está vacío");
            }
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                throw new Exception("El apellido está vacío");
            }
        }

        public List<Miembro> ObtenerAmigos()
        {
            if (_listaAmigos.Count > 0)
            {
                return _listaAmigos;
            }
            return new List<Miembro>();  // retorno una lista vacía
        }

        public void asociarAmigo(Miembro miem)
        {
            _listaAmigos.Add(miem);
        }



    }
}
