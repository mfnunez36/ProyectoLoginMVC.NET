using System.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionDAL
    {
        /// <summary>
        /// Conexión a base de datos de single signed on
        /// </summary>
        public static SqlConnection SQLconnCanchas()
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["canchas"].ConnectionString);
            conexion.Open();
            return conexion;

        }
    }
}
