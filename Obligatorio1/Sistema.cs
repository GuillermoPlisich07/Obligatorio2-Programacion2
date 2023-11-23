namespace Obligatorio1
{
    public class Sistema
    {
        private static Sistema _instancia;

        private List<Usuario> _listaUsuarios = new List<Usuario>();
        private List<Invitacion> _listaInvitaciones = new List<Invitacion>();
        private List<Publicacion> _listaPubicaciones = new List<Publicacion>();
        private List<Reaccion> _listaReacciones = new List<Reaccion>();

        public List<Usuario> ListaUsuarios { get { return _listaUsuarios; } }
        public List<Invitacion> ListaInvitaciones { get { return _listaInvitaciones; } }
        public List<Publicacion> ListaPublicaciones { get { return _listaPubicaciones; } }
        public List<Reaccion> ListaReacciones { get { return _listaReacciones; } }

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }


        /// <summary>
        ///     En esta funcion se llaman a las precargas para ejecutarlas dentro de la clase sistema ya que son funciones privadas.
        /// </summary>
        /// 
        private Sistema()
        {
            Precargas();
        }

        public void Precargas()
        {
            PrecargarMiembros();
            PrecargarAdministradores();
            PrecargarInvitaciones();
            PrecargarPosts();
            PrecargarComentarios();
            PrecargarReacciones();
        }


        /// <summary>
        ///     En esta funcion se precargan todos los mimebros pedidos por las letra del Obligatorio usando una funcion CrearNuevoMiembro que se vera mas adelante
        /// </summary>
        private void PrecargarMiembros()
        {
            Miembro miembro1 = new Miembro("caro19@gmail.com", "Estrella-1", false, "Carolina", "Vazquez", new DateTime(1991, 10, 10));
            CrearNuevoMiembro(miembro1);
            Miembro miembro2 = new Miembro("sofia88@gmail.com", "Lunas-88", false, "Sofia", "Ortiz", new DateTime(1988, 10, 03));
            CrearNuevoMiembro(miembro2);
            Miembro miembro3 = new Miembro("carlos90@gmail.com", "Neptuno-90", false, "Carlos", "Lopez", new DateTime(1995, 10, 03));
            CrearNuevoMiembro(miembro3);
            Miembro miembro4 = new Miembro("juan19@gmail.com", "Jupiter-19", false, "Carlos", "Lopez", new DateTime(1960, 08, 08));
            CrearNuevoMiembro(miembro4);
            Miembro miembro5 = new Miembro("facundo44@gmail.com", "Urano-44", false, "Facundo", "Gomez", new DateTime(1999, 04, 04));
            CrearNuevoMiembro(miembro5);
            Miembro miembro6 = new Miembro("bruno21@gmail.com", "Saturno-21", false, "Bruno", "Gonzalez", new DateTime(2020, 01, 01));
            CrearNuevoMiembro(miembro6);
            Miembro miembro7 = new Miembro("Monica99@gmail.com", "Mercurio*99", false, "Moria", "Casanova", new DateTime(1960, 08, 08));
            CrearNuevoMiembro(miembro7);
            Miembro miembro8 = new Miembro("anita@gmail.com", "Venus.19", false, "Ana", "Moreira", new DateTime(1960, 08, 08));
            CrearNuevoMiembro(miembro8);
            Miembro miembro9 = new Miembro("tony1990@gmail.com", "Tierra_19", false, "Antonio", "Salvat", new DateTime(2021, 06, 06));
            CrearNuevoMiembro(miembro9);
            Miembro miembro10 = new Miembro("second2@gmail.com", "Marte$19", false, "Segundo", "Machado", new DateTime(1988, 08, 08));
            CrearNuevoMiembro(miembro10);
            Miembro miembro11 = new Miembro("zara@gmail.com", "Nept-1771", false, "Zara", "Machado", new DateTime(1990, 08, 08));
            CrearNuevoMiembro(miembro11);       //posicion 10 de la lista
        }


        /// <summary>
        ///     En esta funcion se precarga el administrador que se pide en la letra del Obligatorio usando una funcion CrearNuevoAdministrador que se vera mas adelante
        /// </summary>
        private void PrecargarAdministradores()
        {
            Administrador admin1 = new Administrador("guille77@gmail.com", "Pluton-77", true);
            CrearNuevoAdministrador(admin1);
        }


        /// <summary>
        ///     En esta funcion se precarga las invitaciones que se pide en la letra del Obligatorio usando una funcion CrearNuevaInvitacion que se vera mas adelante
        /// </summary>
        private void PrecargarInvitaciones()
        {
            //Invitaciones del miembro en posicion 0 en estado APROBADO
            Invitacion invita1 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[1] as Miembro, "aprobada", new DateTime(1988, 08, 08));
            CrearNuevaInvitacion(invita1);
            Miembro solicitado1 = _listaUsuarios[0] as Miembro;
            Miembro solicitante1 = _listaUsuarios[1] as Miembro;
            solicitado1.asociarAmigo(solicitante1);
            solicitante1.asociarAmigo(solicitado1);

            Invitacion invita2 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[2] as Miembro, "aprobada", new DateTime(1990, 09, 15));
            CrearNuevaInvitacion(invita2);
            Miembro solicitante2 = _listaUsuarios[2] as Miembro;
            solicitado1.asociarAmigo(solicitante2);
            solicitante2.asociarAmigo(solicitado1);

            Invitacion invita3 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[3] as Miembro, "aprobada", new DateTime(1992, 11, 20));
            CrearNuevaInvitacion(invita3);
            Miembro solicitante3 = _listaUsuarios[3] as Miembro;
            solicitado1.asociarAmigo(solicitante3);
            solicitante3.asociarAmigo(solicitado1);

            Invitacion invita4 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[4] as Miembro, "aprobada", new DateTime(1989, 07, 05));
            CrearNuevaInvitacion(invita4);
            Miembro solicitante4 = _listaUsuarios[4] as Miembro;
            solicitado1.asociarAmigo(solicitante4);
            solicitante4.asociarAmigo(solicitado1);

            Invitacion invita5 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[5] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita5);
            Miembro solicitante5 = _listaUsuarios[5] as Miembro;
            solicitado1.asociarAmigo(solicitante5);
            solicitante5.asociarAmigo(solicitado1);

            Invitacion invita6 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[6] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita6);
            Miembro solicitante6 = _listaUsuarios[6] as Miembro;
            solicitado1.asociarAmigo(solicitante6);
            solicitante6.asociarAmigo(solicitado1);

            Invitacion invita7 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[7] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita7);
            Miembro solicitante7 = _listaUsuarios[7] as Miembro;
            solicitado1.asociarAmigo(solicitante7);
            solicitante7.asociarAmigo(solicitado1);

            Invitacion invita8 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[8] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita8);
            Miembro solicitante8 = _listaUsuarios[8] as Miembro;
            solicitado1.asociarAmigo(solicitante8);
            solicitante8.asociarAmigo(solicitado1);

            Invitacion invita9 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[9] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita9);
            Miembro solicitante9 = _listaUsuarios[9] as Miembro;
            solicitado1.asociarAmigo(solicitante9);
            solicitante9.asociarAmigo(solicitado1);

            Invitacion invita10 = new Invitacion(_listaUsuarios[0] as Miembro, _listaUsuarios[10] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita10);
            Miembro solicitante10 = _listaUsuarios[10] as Miembro;
            solicitado1.asociarAmigo(solicitante10);
            solicitante10.asociarAmigo(solicitado1);


            //Invitaciones del miembro en posicion 1 en estado APROBADO
            Invitacion invita11 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[2] as Miembro, "aprobada", new DateTime(1988, 08, 08));
            CrearNuevaInvitacion(invita11);
            Miembro solicitado2 = _listaUsuarios[1] as Miembro;
            solicitado2.asociarAmigo(solicitante2);
            solicitante1.asociarAmigo(solicitado2);


            Invitacion invita12 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[3] as Miembro, "aprobada", new DateTime(1990, 09, 15));
            CrearNuevaInvitacion(invita12);
            solicitado2.asociarAmigo(solicitante3);
            solicitante3.asociarAmigo(solicitado2);

            Invitacion invita13 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[4] as Miembro, "aprobada", new DateTime(1992, 11, 20));
            CrearNuevaInvitacion(invita13);
            solicitado2.asociarAmigo(solicitante4);
            solicitante4.asociarAmigo(solicitado2);

            Invitacion invita14 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[5] as Miembro, "aprobada", new DateTime(1989, 07, 05));
            CrearNuevaInvitacion(invita14);
            solicitado2.asociarAmigo(solicitante5);
            solicitante5.asociarAmigo(solicitado2);

            Invitacion invita15 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[6] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita15);
            solicitado2.asociarAmigo(solicitante6);
            solicitante6.asociarAmigo(solicitado2);

            Invitacion invita16 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[7] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita16);
            solicitado2.asociarAmigo(solicitante7);
            solicitante7.asociarAmigo(solicitado2);

            Invitacion invita17 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[8] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita17);
            solicitado2.asociarAmigo(solicitante8);
            solicitante8.asociarAmigo(solicitado2);

            Invitacion invita18 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[9] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita18);
            solicitado2.asociarAmigo(solicitante9);
            solicitante9.asociarAmigo(solicitado2);

            Invitacion invita19 = new Invitacion(_listaUsuarios[1] as Miembro, _listaUsuarios[10] as Miembro, "aprobada", new DateTime(2023, 09, 27));
            CrearNuevaInvitacion(invita19);
            solicitado2.asociarAmigo(solicitante10);
            solicitante10.asociarAmigo(solicitado2);



            //invitacion en estado RECHAZADA
            Invitacion invita20 = new Invitacion(_listaUsuarios[2] as Miembro, _listaUsuarios[3] as Miembro, "rechazada", new DateTime(2020, 03, 03));
            CrearNuevaInvitacion(invita20);

            //invitacion en estado PROCESO
            Invitacion invita21 = new Invitacion(_listaUsuarios[3] as Miembro, _listaUsuarios[4] as Miembro, "proceso", new DateTime(2022, 08, 08));
            CrearNuevaInvitacion(invita21);
        }


        /// <summary>
        ///     En esta funcion se precargan los Posts que se pide en la letra del Obligatorio usando una funcion CrearNuevoPost que se vera mas adelante
        /// </summary>
        private void PrecargarPosts()
        {
            //Post [0]
            Post post1 = new Post("vacaciones en Miami", new DateTime(2018, 08, 08), _listaUsuarios[0] as Miembro, "primavera en USA 🌈🌼", "img.jpg", "privado", false, false,0, 0, 0);
            CrearNuevoPost(post1);
            //Post [1]
            Post post2 = new Post("Recuerdos de París", new DateTime(2019, 06, 15), _listaUsuarios[1] as Miembro, "Días inolvidables en la Ciudad del Amor. 💖", "paris.jpg", "publico", false, true, 0, 0, 0);
            CrearNuevoPost(post2);
            //Post [2]
            Post post3 = new Post("Aventuras en Tailandia", new DateTime(2020, 07, 25), _listaUsuarios[2] as Miembro, "Explorando la belleza de Tailandia. 🌴🌞", "tailandia.jpg", "publico", true, true, 0, 0, 0);
            CrearNuevoPost(post3);
            //Post [3]
            Post post4 = new Post("Excursión a Machu Picchu", new DateTime(2021, 09, 10), _listaUsuarios[3] as Miembro, "Un sueño hecho realidad en las alturas de Perú. 🏞️", "machupicchu.jpg", "publico", false, true, 0, 0, 0);
            CrearNuevoPost(post4);
            //Post [4]
            Post post5 = new Post("Noche de concierto en Nueva York", new DateTime(2022, 07, 03), _listaUsuarios[4] as Miembro, "Vibrando al ritmo de la Gran Manzana. 🎶🗽", "nyconcert.jpg", "publico", false, true, 0, 0, 0);
            CrearNuevoPost(post5);
        }


        /// <summary>
        ///     En esta funcion se precargan los Comentarios que se pide en la letra del Obligatorio usando una funcion CrearNuevoComentario que se vera mas adelante
        /// </summary>
        private void PrecargarComentarios()
        {
            //Post [0]
            Comentario comentario1 = new Comentario(_listaPubicaciones[0] as Post, "¡Wow, esta foto es simplemente impresionante! 😍", new DateTime(2023, 01, 08), _listaUsuarios[1] as Miembro, "foto divi", _listaPubicaciones[0].EsPublico,0, 0, 0);
            CrearNuevoComentario(comentario1);
            Post Post1 = _listaPubicaciones[0] as Post;
            Post1.AsociarComentario(comentario1);

            Comentario comentario2 = new Comentario(_listaPubicaciones[0] as Post, "¡¿Dónde tomaste esta increíble imagen? 😮", new DateTime(2023, 01, 09), _listaUsuarios[1] as Miembro, "foton", _listaPubicaciones[0].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario2);
            Post1.AsociarComentario(comentario2);

            Comentario comentario3 = new Comentario(_listaPubicaciones[0] as Post, "¡Qué lugar tan hermoso! Me encantaría visitarlo algún día. 🌴☀️", new DateTime(2023, 02, 08), _listaUsuarios[1] as Miembro, "hermoso", _listaPubicaciones[0].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario3);
            Post1.AsociarComentario(comentario3);


            //Post [1]
            Comentario comentario4 = new Comentario(_listaPubicaciones[1] as Post, "La naturaleza siempre nos sorprende con su belleza. 🍃💖", new DateTime(2023, 03, 08), _listaUsuarios[2] as Miembro, "belleza", _listaPubicaciones[1].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario4);
            Post Post2 = _listaPubicaciones[1] as Post;
            Post2.AsociarComentario(comentario4);

            Comentario comentario5 = new Comentario(_listaPubicaciones[1] as Post, "No puedo evitar envidiar tu talento para la fotografía. 📷💫", new DateTime(2023, 04, 08), _listaUsuarios[2] as Miembro, "talentoso", _listaPubicaciones[1].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario5);
            Post2.AsociarComentario(comentario5);

            Comentario comentario6 = new Comentario(_listaPubicaciones[1] as Post, "Esa puesta de sol es simplemente mágica. ✨🌅", new DateTime(2023, 04, 08), _listaUsuarios[2] as Miembro, "magic", _listaPubicaciones[1].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario6);
            Post2.AsociarComentario(comentario6);


            //Post [2]
            Comentario comentario7 = new Comentario(_listaPubicaciones[2] as Post, "Qué foto tan relajante! Me hace sentir en paz. 🌿🌊", new DateTime(2023, 03, 08), _listaUsuarios[1] as Miembro, "peace", _listaPubicaciones[2].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario7);
            Post Post3 = _listaPubicaciones[2] as Post;
            Post3.AsociarComentario(comentario7);


            Comentario comentario8 = new Comentario(_listaPubicaciones[2] as Post, "Estoy obsesionado/a con tus fotos, siempre son asombrosas. 📸👏", new DateTime(2023, 04, 08), _listaUsuarios[1] as Miembro, "awesome", _listaPubicaciones[2].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario8);
            Post3.AsociarComentario(comentario8);


            Comentario comentario9 = new Comentario(_listaPubicaciones[2] as Post, "Esa sonrisa tuya ilumina la foto. 😄💕", new DateTime(2023, 04, 08), _listaUsuarios[1] as Miembro, "smile", _listaPubicaciones[2].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario9);
            Post3.AsociarComentario(comentario9);

            //Post [3]
            Comentario comentario10 = new Comentario(_listaPubicaciones[3] as Post, "¡Estás viviendo la vida al máximo! 🙌", new DateTime(2023, 03, 08), _listaUsuarios[1] as Miembro, "max", _listaPubicaciones[3].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario10);
            Post Post4 = _listaPubicaciones[3] as Post;
            Post4.AsociarComentario(comentario10);


            Comentario comentario11 = new Comentario(_listaPubicaciones[3] as Post, "¿Cuál es el secreto para verte tan bien en todas tus fotos? 😁", new DateTime(2023, 04, 08), _listaUsuarios[1] as Miembro, "divi", _listaPubicaciones[3].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario11);
            Post4.AsociarComentario(comentario11);

            Comentario comentario12 = new Comentario(_listaPubicaciones[3] as Post, "Esta imagen me transporta a otro mundo. 🚀🌌", new DateTime(2023, 04, 08), _listaUsuarios[1] as Miembro, "mundo", _listaPubicaciones[3].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario12);
            Post4.AsociarComentario(comentario12);


            //Post [4]
            Comentario comentario13 = new Comentario(_listaPubicaciones[4] as Post, "La naturaleza siempre nos sorprende con su belleza. 🍃💖", new DateTime(2023, 03, 08), _listaUsuarios[3] as Miembro, "belleza", _listaPubicaciones[4].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario13);
            Post Post5 = _listaPubicaciones[4] as Post;
            Post5.AsociarComentario(comentario13);

            Comentario comentario14 = new Comentario(_listaPubicaciones[4] as Post, "No puedo evitar envidiar tu talento para la fotografía. 📷💫", new DateTime(2023, 04, 08), _listaUsuarios[3] as Miembro, "talentoso", _listaPubicaciones[4].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario14);
            Post5.AsociarComentario(comentario14);


            Comentario comentario15 = new Comentario(_listaPubicaciones[4] as Post, "No puedo evitar envidiar tu talento para la fotografía. 📷💫", new DateTime(2023, 04, 08), _listaUsuarios[3] as Miembro, "talentoso", _listaPubicaciones[4].EsPublico, 0, 0, 0);
            CrearNuevoComentario(comentario15);
            Post5.AsociarComentario(comentario15);
        }


        /// <summary>
        ///     En esta funcion se precargan las Reacciones que se pide en la letra del Obligatorio usando una funcion CrearNuevaReaccion que se vera mas adelante
        /// </summary>
        private void PrecargarReacciones()
        {
            //reacciones a Post
            Reaccion reaccion1 = new Reaccion("like", _listaUsuarios[1] as Miembro, _listaPubicaciones[0] as Post);
            CrearNuevaReaccion(reaccion1);
            Reaccion reaccion2 = new Reaccion("like", _listaUsuarios[1] as Miembro, _listaPubicaciones[2] as Post);
            CrearNuevaReaccion(reaccion2);
            //reacciones a Comentarios
            Reaccion reaccion3 = new Reaccion("like", _listaUsuarios[2] as Miembro, _listaPubicaciones[3] as Post);
            CrearNuevaReaccion(reaccion3);
            Reaccion reaccion4 = new Reaccion("dislike", _listaUsuarios[3] as Miembro, _listaPubicaciones[4] as Post);
            CrearNuevaReaccion(reaccion4);
        }


        /// <summary>
        ///     Esta funcion recibe un tipo Adeministrador y se valua que este no sea vacio y que no este ya en la lista de usuarios
        ///     una vez validado esto se agrega a la lista
        /// </summary>
        /// <returns>retorna un mensaje de exito en el mejor de los casos, sino larga una exepcion</returns>
        public string CrearNuevoAdministrador(Administrador administrador)
        {
            if (administrador == null)
            {
                throw new Exception("El admin recibido esta vacio.");
            }
            if (_listaUsuarios.Contains(administrador))
            {
                throw new Exception($"El admin ya existe.");
            }
            administrador.ValidarAdmin();
            _listaUsuarios.Add(administrador);
            return "Se creo el miembro correctamente";
        }


        /// <summary>
        ///     Esta funcion recibe un tipo Invitacion y se valua que no este ya en la lista de Invitaciones
        ///     una vez validado esto se agrega a la lista
        /// </summary>
        public void CrearNuevaInvitacion(Invitacion invitacion)
        {
            if (_listaInvitaciones.Contains(invitacion))
            {
                throw new Exception($"La invitacion ya existe");
            }
            invitacion.ValidarInvitacion();
            _listaInvitaciones.Add(invitacion);
        }

        public void AgregarAmigoSistema(Invitacion invitacion)
        {
            try
            {
                if (!_listaInvitaciones.Contains(invitacion))
                {
                    throw new Exception($"La invitacion no existe");
                }

                Miembro miembro1 = ObtenerMiembro(invitacion.MiembroSolicitado.Email);
                Miembro miembro2 = ObtenerMiembro(invitacion.MiembroSolicitante.Email);
                List<Miembro> amigos1 = miembro1.ObtenerAmigos();
                List<Miembro> amigos2 = miembro2.ObtenerAmigos();

                if (invitacion.Estado == "pendiente" && !amigos1.Contains(miembro2) && !amigos2.Contains(miembro1))
                {
                    invitacion.Estado = "aprobada";
                    miembro1.asociarAmigo(miembro2);
                    miembro2.asociarAmigo(miembro1);
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public void RechazarInvitacionSistema(Invitacion invitacion)
        {
            try
            {
                if (!_listaInvitaciones.Contains(invitacion))
                {
                    throw new Exception($"La invitacion no existe");
                }

                if (invitacion.Estado == "pendiente")
                {
                    invitacion.Estado = "rechazada";
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        


        /// <summary>
        ///     Esta funcion recibe un tipo Post y se valua que no este ya en la lista de Publicacion
        ///     una vez validado esto se agrega a la lista
        /// </summary>
        public void CrearNuevoPost(Post post)
        {
            if (_listaPubicaciones.Contains(post))
            {
                throw new Exception($"El Post ya fue publicado");
            }
            post.ValidarPost();
            _listaPubicaciones.Add(post);
        }


        /// <summary>
        ///     Esta funcion recibe un tipo Comentario y se valua que no este ya en la lista de Publicacion
        ///     una vez validado esto se agrega a la lista
        /// </summary>
        public void CrearNuevoComentario(Comentario coment)
        {
            if (_listaPubicaciones.Contains(coment))
            {
                throw new Exception($"El Comentario ya fue publicado");
            }
            coment.ValidarComentario();
            _listaPubicaciones.Add(coment);
        }


        /// <summary>
        ///     Esta funcion recibe un tipo Reaccion y se valua que no este ya en la lista de Reaccion
        ///     una vez validado esto se agrega a la lista
        /// </summary>
        public void CrearNuevaReaccion(Reaccion react)
        {
            if (_listaReacciones.Contains(react))
            {
                throw new Exception($"Ya existe reaccion");
            }
            react.ValidarReaccion();
            ActualizarContadoresReacciones(react);
            _listaReacciones.Add(react);
        }


        public void ActualizarContadoresReacciones(Reaccion react)
        {
            if (react.TipoReaccion == "like") 
            { 
                react.PublicacionReaccionada.CdadLike++;
            }
            else if (react.TipoReaccion == "dislike")
            {
                react.PublicacionReaccionada.CdadDislike++;
            }
            react.PublicacionReaccionada.VA = CalcularVA(react.PublicacionReaccionada);
        }


        /// <summary>
        ///     Esta funcion recibe un email, y busca en la lista de Usuarios la coincidencia con el mail de los usuarios
        /// </summary>
        /// <returns>retorna un mimebro en el mejor de los casos, sino retorna null</returns>
        public Miembro ObtenerMiembro(string email)
        {
            Miembro? miembro = null;
            foreach (Usuario user in _listaUsuarios)
            {
                if (user is Miembro && user.Email == email)
                {
                    miembro = (Miembro)user;
                    break;
                }
                
            }
            return miembro;
        }


        public Usuario ObtenerUsuario(string email, string pass)
        {
            Usuario? usuar = null;
            foreach (Usuario usu in _listaUsuarios)
            {
                if (usu.Email == email && usu.Password == pass)
                {
                    usuar = usu;
                    break;
                }
            }
            return usuar;
        }


        /// <summary>
        ///     Esta funcion recibe un email, y recorre toda las lista de usuarios en busca de la coincidencia de este email
        /// </summary>
        /// <returns>retorna true si existe un miembro con este email, sino false en el caso contrario</returns>
        public bool ExisteEmail(string email)
        {
            bool existe = false;
            foreach (Usuario usu in _listaUsuarios)
            {
                if (usu.Email == email)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }


        /// <summary>
        ///     Esta funcion recibe un tipo Mimebro y se valua que este no sea vacio y que no este ya en la lista de usuarios
        ///     una vez validado esto se agrega a la lista de usuarios
        /// </summary>
        /// <returns>retorna un mensaje de exito en el mejor de los casos, sino larga una exepcionreturns>
        public string CrearNuevoMiembro(Miembro miembro)
        {

            if (miembro == null)
            {
                throw new Exception("El miembro recibido esta vacio.");
            }
            if (_listaUsuarios.Contains(miembro))
            {
                throw new Exception($"El miembro ya existe.");
            }
            miembro.ValidarMiembro();
            _listaUsuarios.Add(miembro);
            return "Se creo el miembro correctamente";
        }

        public List<Post> ListarTodasLosPost()
        {
            List<Post> AuxList = new List<Post>();
            List<Publicacion> listaPubliaciones = _listaPubicaciones;
            foreach (Publicacion unPubli in listaPubliaciones)
            {
                if (unPubli is Post)
                {
                    AuxList.Add((Post)unPubli);
                }
            }
            return AuxList;
        }

        public bool SonAmigos(Miembro logueado, Miembro aComprobar)
        {
            bool esAmigo= false;
            List<Miembro> amigos= logueado.ObtenerAmigos();
            foreach (var unAmig in amigos)
            {
                if (unAmig==aComprobar)
                {
                    esAmigo = true;
                }
            }

            return esAmigo;
        }


        /// <summary>
        ///     En esta funcion se retorna en una lista todas las publicaciones realizadas por el mimebro que coincida con el email de referencia.
        /// </summary>
        /// <returns>retorna una lista filtrada de publicacion</returns>
        public List<Publicacion> ListarPublicaciones(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Hubo un error en el pasaje de datos del email");
                }

                Usuario.ValidarEmail(email);
                List<Publicacion> listaAux = new List<Publicacion>();

                Miembro? miembro = ObtenerMiembro(email);

                if (miembro != null)
                {
                    foreach (Publicacion unapub in _listaPubicaciones)
                    {
                        if (unapub.Miembro == miembro)
                        {
                            listaAux.Add(unapub);
                        }
                    }
                }
                else
                {
                    throw new Exception("El miembro no existe");
                }

                return listaAux;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // ACA ----------------------------------------
        public List<Publicacion> ListarTodasPublicacionesParaMiembro(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Error en el email");
                }

                Usuario.ValidarEmail(email);
                List<Publicacion> listaAux = new List<Publicacion>();
                Miembro? miembro = ObtenerMiembro(email);
                List<Miembro> listaAmigos = new List<Miembro>();

                if (miembro != null)
                {
                    listaAmigos = miembro.ObtenerAmigos();
                    foreach (Publicacion unapub in _listaPubicaciones)
                    {
                        if (unapub.Miembro == miembro || unapub.EsPublico || listaAmigos.Contains(unapub.Miembro))
                        {
                            listaAux.Add(unapub);
                        }
                    }
                }
                else
                {
                    throw new Exception("El miembro no existe");
                }

                return listaAux;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<Publicacion> ListarPostParaMiembro(string email)
        {
            try
            {
                List<Publicacion> todasPublicaciones = ListarTodasPublicacionesParaMiembro(email);
                List<Publicacion> listaAux = new List<Publicacion>();
                foreach (Publicacion unaPub in todasPublicaciones)
                {
                    if (unaPub is Post)
                    {
                        listaAux.Add((Post)unaPub);
                    }
                }
                return listaAux;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Post> ListarPostDelMiembro(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Hubo un error en el pasaje de datos del email");
                }

                Usuario.ValidarEmail(email);
                List<Post> listaAux = new List<Post>();

                Miembro? miembro = ObtenerMiembro(email);

                if (miembro != null)
                {
                    foreach (Publicacion unPub in _listaPubicaciones)
                    {
                        if (unPub.Miembro == miembro && unPub is Post)
                        {
                            Post p = (Post)unPub;
                            listaAux.Add(p);
                        }
                    }
                }
                else
                {
                    throw new Exception("Miembro no existe");
                }


                return listaAux;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///     Esta funcion toma la lista de publicaciones de la cual requerimos de los comentarios y los evalua por el mimebro que lo realizo si este coincide con el email
        ///     pasado a la funcion, casteamos la publicacion a comentario y añadimos a la nueva lista la refernecia al Post que guarda comentario.
        /// </summary>
        /// <returns>retorna una lista de post filtra</returns>
        public List<Post> ListarPost(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Hubo un error en el pasaje de datos del email");
                }

                Usuario.ValidarEmail(email);
                List<Post> listaAux = new List<Post>();

                Miembro? miembro = ObtenerMiembro(email);

                if (miembro != null)
                {
                    foreach (Publicacion unPub in _listaPubicaciones)
                    {
                        if (unPub.Miembro == miembro && unPub is Comentario)
                        {
                            Comentario unComentario = (Comentario)unPub;
                            listaAux.Add(unComentario.Post);
                        }
                    }
                }
                else
                {
                    throw new Exception("Miembro no existe");
                }


                return listaAux;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        ///     Esta funcion toma la lista de publicaciones y solamente agrega a una lista de tipo post aquellas pubicaciones
        ///     que sean del tipo post que esten entre la fechas 'fechaInicio' y  'fechaFin'.
        ///     Luego de esto se ordena de forma descendente por el titulo del post
        /// </summary>
        /// <returns>retorna una lista de post filtrada</returns>
        public List<Post> ListarPostFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio == DateTime.MinValue && fechaFin == DateTime.MinValue)
                {
                    throw new Exception("Hubo un error en pasajes de fechas");
                }

                List<Post> listaAux = new List<Post>();

                foreach (Publicacion unPub in _listaPubicaciones)
                {
                    if (unPub is Post post && post.Fecha >= fechaInicio && post.Fecha <= fechaFin)
                    {
                        listaAux.Add(post);
                    }
                }

                // Ordenar los posts por título en forma descendente usando una función de comparación lambda
                listaAux.Sort((post1, post2) => string.Compare(post2.Titulo, post1.Titulo));


                return listaAux;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        ///     Esta funcion toma el email del miembro y lo compara con todas las publicaciones que contengan un Mimebro con el mismo email
        /// </summary>
        /// <returns>retorna la cantidad de coincidencias</returns>
        public int CantidadPublicaciones(string mail)
        {
            int cant = 0;
            foreach (Publicacion pub in _listaPubicaciones)
            {
                if (pub.Miembro.Email == mail)
                {
                    cant++;
                }
            }
            return cant;
        }


        /// <summary>
        ///     Esta funcion toma cada miembro de la lista de usuario y cuenta la cantidad de publicaciones de cada uno y la compara con la variable 'cantidadPublicacionesMiembro'
        ///     evaluando cual es mayo, en el caso de que la cantidad de publicaciones del mimebro sea mayor a la variable 'cantidadPublicacionesMiembro' esta pasa a tomar la cantidad
        ///     de publiaciones del miembro.
        ///     Luego de esto se guardan todos los usuarios que tengan la misma cantidad de publiaciones que la variable 'cantidadPublicacionesMiembro' a una lista nueva.
        /// </summary>
        /// <returns>retorna una lista de mimebros filtrada</returns>
        public List<Miembro> MiembrosMasPublicaciones()
        {
            List<Miembro> listaAux = new List<Miembro>();
            int cantidadPublicacionesMax = 0;

            foreach (Usuario usu in _listaUsuarios)
            {
                if (usu is Miembro)
                {
                    Miembro miem = (Miembro)usu;
                    int cantidadPublicacionesMiembro = CantidadPublicaciones(miem.Email);
                    if (cantidadPublicacionesMiembro > cantidadPublicacionesMax)
                    {
                        cantidadPublicacionesMax = cantidadPublicacionesMiembro;    //guardo la maxima cantidad de Publicaciones
                    }

                }

            }

            foreach (Usuario usu in _listaUsuarios)
            { //recorro la lista de nuevo para añadir a los miembros con mas pub a la lista

                if (usu is Miembro)
                {
                    Miembro miem = (Miembro)usu;
                    int cantidadPublicacionesMiembro = CantidadPublicaciones(miem.Email);
                    if (cantidadPublicacionesMiembro == cantidadPublicacionesMax)
                    {
                        listaAux.Add(miem);
                    }
                }
            }

            return listaAux;

        }

        public List<Miembro> ListarMiembros()
        {
            List<Miembro> listaAux = new List<Miembro>();

            foreach (Usuario usu in _listaUsuarios)
            {
                if (usu is Miembro)
                {
                    Miembro miem = (Miembro)usu;
                    listaAux.Add(miem);
                }
            }

            listaAux.Sort();
            return listaAux;
        }

        public List<Miembro> ListarMiembrosParaSolicitudAmistad(string email)   //paso como parametro el mail de usuario logueado
        {
            Miembro? miembro = ObtenerMiembro(email);
            List<Miembro> listaAux = new List<Miembro>();

            if (miembro != null)
            {
                List<Miembro> listaAmigos = miembro.ObtenerAmigos();
                foreach (Usuario usu in _listaUsuarios)
                {
                    //chequeo que en la lista no se agregue al usuario loguado y que no sea amigo
                    if (usu is Miembro && usu != miembro && !listaAmigos.Contains(usu))
                    {
                        Miembro miem = (Miembro)usu;
                        listaAux.Add(miem);
                    }
                    listaAux.Sort();
                }
            }
            return listaAux;
        }


        public List<Invitacion> ObtenerInvitacionesParaUnMiembro(Miembro miem)
        {
            List<Invitacion> listaAux = new List<Invitacion>();
            if (miem != null)
            {
                foreach (Invitacion unaI in _listaInvitaciones)
                {
                    if (unaI.MiembroSolicitante == miem || unaI.MiembroSolicitado == miem)
                    {
                        listaAux.Add(unaI);
                    }
                }
            }
            return listaAux;
        }

        public Invitacion ObtenerInvitacionPorID(int IdInvita)
        {
            foreach (Invitacion unaI in _listaInvitaciones)
            {
                if (unaI.Id == IdInvita)
                {
                    return unaI;
                }
            }
            return null;
        }

        public Publicacion ObtenerPublicacion(string id)
        {
            Publicacion obj = null;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {

                    foreach (Publicacion unPub in _listaPubicaciones)
                    {
                        if (unPub is Post post && post.Id == int.Parse(id))
                        {
                            obj = unPub;
                        }
                    }
                }
                else
                {
                    throw new Exception("El id esta vacio");
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return obj;
        }

        public Reaccion BuscarReaccion(Publicacion unPub, Miembro miem)
        {
            Reaccion obj = null;
            try
            {
                if (unPub != null)
                {
                    if (miem != null)
                    {
                        foreach (Reaccion unReaccion in _listaReacciones)
                        {
                            if (unReaccion.PublicacionReaccionada == unPub && unReaccion.Miembro == miem)
                            {
                                obj = unReaccion;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("No existe el miembro");
                    }
                }
                else
                {
                    throw new Exception("No existe la publicacion");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return obj;
        }



        //Metodo para calcular Valor de Aceptacion
        public decimal CalcularVA(Publicacion unaPub)
        {
            decimal VA = 0;
            VA = (unaPub.CdadLike * 5) + (unaPub.CdadDislike * (-2));
            if (unaPub is Post && unaPub.EsPublico)
            {
                VA = VA + 10;
            }
            return VA;
        }













    }
}
