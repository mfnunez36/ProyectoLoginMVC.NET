using System;
using System.Collections.Generic;

namespace DTO
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nac { get; set; }
        public string contraseña { get; set; }
        public string correo { get; set; }
        public int telefono { get; set; }
        public bool vigente { get; set; }
        public List<UsuarioPerfilDTO> usuarioPerfiles { get; set; }
    }
}
