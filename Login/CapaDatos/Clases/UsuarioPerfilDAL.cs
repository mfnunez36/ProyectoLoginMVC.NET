using System.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioPerfilDAL
    {

        //AGREGAR USUARIO CON PERFILES
        public bool AgregarUsuarioPerfil(int id_perfil)
        {
            var resultado = false;

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("UsuarioPerfil_Agregar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id_perfil", id_perfil));

                    comando.ExecuteNonQuery();

                    resultado = true;
                }
            }

            return resultado;

        }
    }
}
