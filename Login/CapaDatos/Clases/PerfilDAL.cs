using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class PerfilDAL
    {
        //LISTAR PERFILES
        public List<PerfilDTO> ObtenerPerfiles()
        {
            //Se crea la lista que se enviara como resultado.
            List<PerfilDTO> lista = new List<PerfilDTO>();
            //Se instancia la conexion de datos
            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                // se setea el comando que define el procedimiento almacenado y conexion a utilizar para obtener los datos desde la bd.
                using (SqlCommand comando = new SqlCommand("Perfil_Listar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    //Se instancia el adapter, que sirve para ejecutar el comando.
                    using (SqlDataAdapter adap = new SqlDataAdapter(comando))
                    {
                        DataTable tbResultados = new DataTable();

                        //ejecuto el comando utilizando el adapter y lleno la tabla con los datos obtenidos.
                        adap.Fill(tbResultados);

                        //si se lograron extraer datos entonces agregare todos los objetos a la lista.
                        if (tbResultados.Rows.Count > 0 || tbResultados.Rows != null)
                        {
                            for (int i = 0; i < tbResultados.Rows.Count; i++)
                            {
                                DataRow fila = tbResultados.Rows[i];
                                PerfilDTO perfil = new PerfilDTO();
                                perfil.id = Convert.ToInt32(fila["id"]);
                                perfil.tipo = Convert.ToString(fila["tipo"]);
                                perfil.descripcion = Convert.ToString(fila["descripcion"]);
                                perfil.vigente = Convert.ToBoolean(fila["vigente"]);
                                lista.Add(perfil);
                            }
                        }
                    }//FIN ADAPTER
                }//FIN COMANDO
            }//FIN CONEXION

            return lista;
        }



        //TRAER PERFIL POR ID
        public PerfilDTO PerfilByID(int id)
        {
            var perfil = new PerfilDTO();

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Perfil_BuscarPerfil_ID", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id", id));

                    using (var read = comando.ExecuteReader())
                    {
                        read.Read();
                        if (read.HasRows)
                        {
                            perfil.id = Convert.ToInt32(read["id"]);
                            perfil.tipo = Convert.ToString(read["tipo"]);
                            perfil.descripcion = Convert.ToString(read["descripcion"]);
                            perfil.vigente = Convert.ToBoolean(read["vigente"]);
                        }
                    }
                }
            }

            return perfil;
        }




        //AGREGAR PERFIL
        public bool AgregarPerfil(PerfilDTO perfilDTO)
        {
            var resultado = false;

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Perfil_Agregar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@tipo", perfilDTO.tipo));
                    comando.Parameters.Add(new SqlParameter("@descripcion", perfilDTO.descripcion));

                    comando.ExecuteNonQuery();

                    resultado = true;
                }
            }

            return resultado;

        }



        //EDITAR PERFIL
        public bool EditarPerfil(PerfilDTO perfilDTO)
        {
            var resultado = false;

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Perfil_Editar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id", perfilDTO.id));
                    comando.Parameters.Add(new SqlParameter("@tipo", perfilDTO.tipo));
                    comando.Parameters.Add(new SqlParameter("@descripcion", perfilDTO.descripcion));
                    comando.Parameters.Add(new SqlParameter("@vigente", perfilDTO.vigente));

                    comando.ExecuteNonQuery();

                    resultado = true;
                }
            }

            return resultado;
        }



        //ELIMINAR PERFIL
        public bool EliminarPerfil(int id)
        {
            var resultado = false;

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Perfil_Eliminar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id", id));

                    comando.ExecuteNonQuery();

                    resultado = true;
                }
            }

            return resultado;

        }
    }
}
