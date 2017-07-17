using System;
using System.ComponentModel.DataAnnotations;

namespace WebLogin.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }

        [Required, StringLength(16)]
        public string rut { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento requerido")]
        [DataType(DataType.Date)]
        public DateTime fecha_nac { get; set; }

        [Required(ErrorMessage = "El Contraseña es requerido")]
        public string contraseña { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El Email ingresado no es valido")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El telefono ingresado no es valido")]
        public int telefono { get; set; }

        public bool vigente { get; set; }
    }
}