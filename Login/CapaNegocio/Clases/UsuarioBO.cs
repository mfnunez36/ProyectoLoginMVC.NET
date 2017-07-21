using CapaDatos;
using DTO;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class UsuarioBO
    {
        UsuarioDAL usuarioDal = new UsuarioDAL();
        UsuarioPerfilDAL usuarioperfilDal = new UsuarioPerfilDAL();

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            return usuarioDal.ObtenerUsuarios();
        }

        public UsuarioDTO UsuarioByID(int id)
        {
            return usuarioDal.UsuarioByID(id);
        }

        public int AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            return usuarioDal.AgregarUsuario(usuarioDTO);
        }

        public bool EliminarUsuario(int id)
        {
            return usuarioDal.EliminarUsuario(id);
        }

        public bool EditarUsuario(UsuarioDTO usuarioDTO)
        {
            return usuarioDal.EditarUsuario(usuarioDTO);
        }
        public bool Agregar_UsuarioPerfil(int id_perfil)
        {
            return usuarioperfilDal.AgregarUsuarioPerfil(id_perfil);
        }

        public UsuarioDTO LogIn(string correo, string contraseña)
        {
            return usuarioDal.LogIn(correo, contraseña);
        }
    }
}
