using CapaDatos;
using DTO;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class PerfilBO
    {
        PerfilDAL perfilDal = new PerfilDAL();

        public List<PerfilDTO> ObtenerPerfiles()
        {
            return perfilDal.ObtenerPerfiles();
        }

        public PerfilDTO PerfilByID(int id)
        {
            return perfilDal.PerfilByID(id);
        }

        public bool AgregarPerfil(PerfilDTO perfilDTO)
        {
            return perfilDal.AgregarPerfil(perfilDTO);
        }

        public bool EliminarPerfil(int id)
        {
            return perfilDal.EliminarPerfil(id);
        }

        public bool EditarPerfil(PerfilDTO perfilDTO)
        {
            return perfilDal.EditarPerfil(perfilDTO);
        }
    }
}
