using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class UsuarioDAL
    {
        //LISTAR USUARIOS
        public List<UsuarioDTO> ObtenerUsuarios()
        {
            //Se crea la lista que se enviara como resultado.
            List<UsuarioDTO> lista = new List<UsuarioDTO>();


            //Se instancia la conexion de datos
            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                // se setea el comando que define el procedimiento almacenado y conexion a utilizar para obtener los datos desde la bd.
                using (SqlCommand comando = new SqlCommand("Usuario_Listar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    //Se instancia el adapter, que sirve para ejecutar el comando.
                    using (SqlDataAdapter adap = new SqlDataAdapter(comando))
                    {
                        DataTable tbResultados = new DataTable();

                        //ejecuto el comando utilizando el adapter y lleno la tabla con los datos obtenidos.
                        adap.Fill(tbResultados);

                        //si se lograron extraer datos entonces agregare todos los objetos a la lista.
                        if (tbResultados.Rows.Count > 0 && tbResultados.Rows != null)
                        {
                            for (int i = 0; i < tbResultados.Rows.Count; i++)
                            {
                                DataRow fila = tbResultados.Rows[i];
                                UsuarioDTO Usuario = new UsuarioDTO();
                                Usuario.id = Convert.ToInt32(fila["id"]);
                                Usuario.rut = Convert.ToString(fila["rut"]);
                                Usuario.nombre = Convert.ToString(fila["nombre"]);
                                Usuario.apellido = Convert.ToString(fila["apellido"]);
                                Usuario.fecha_nac = Convert.ToDateTime(fila["fecha_nac"]);
                                Usuario.contraseña = Convert.ToString(fila["contraseña"]);
                                Usuario.correo = Convert.ToString(fila["correo"]);
                                Usuario.telefono = Convert.ToInt32(fila["telefono"]);
                                Usuario.vigente = Convert.ToBoolean(fila["vigente"]);

                                lista.Add(Usuario);
                            }
                        }
                    }//FIN ADAPTER

                }//FIN COMANDO

            }//FIN CONEXION    

            return lista;
        }



        //TRAER USUARIO POR ID
        public UsuarioDTO UsuarioByID(int id)
        {
            var Usuario = new UsuarioDTO();

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Usuario_BuscarUsuario_ID", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id", id));

                    using (var read = comando.ExecuteReader())
                    {
                        read.Read();
                        if (read.HasRows)
                        {
                            Usuario.id = Convert.ToInt32(read["id"]);
                            Usuario.rut = Convert.ToString(read["rut"]);
                            Usuario.nombre = Convert.ToString(read["Nombre"]);
                            Usuario.apellido = Convert.ToString(read["Apellido"]);
                            Usuario.fecha_nac = Convert.ToDateTime(read["fecha_nac"]);
                            Usuario.contraseña = Convert.ToString(read["contraseña"]);
                            Usuario.telefono = Convert.ToInt32(read["telefono"]);
                            Usuario.correo = Convert.ToString(read["correo"]);
                            Usuario.vigente = Convert.ToBoolean(read["vigente"]);
                        }
                    }
                }
            }

            return Usuario;
        }




        //AGREGAR USUARIO
        public int AgregarUsuario(UsuarioDTO usuarioDTO)
        {

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Usuario_Agregar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@rut", usuarioDTO.rut));
                    comando.Parameters.Add(new SqlParameter("@nombre", usuarioDTO.nombre));
                    comando.Parameters.Add(new SqlParameter("@apellido", usuarioDTO.apellido));
                    comando.Parameters.Add(new SqlParameter("@fecha_nac", usuarioDTO.fecha_nac));
                    comando.Parameters.Add(new SqlParameter("@contraseña", usuarioDTO.contraseña));
                    comando.Parameters.Add(new SqlParameter("@correo", usuarioDTO.correo));
                    comando.Parameters.Add(new SqlParameter("@telefono", usuarioDTO.telefono));

                    using (var read = comando.ExecuteReader())
                    {
                        read.Read();
                        if (read.HasRows)
                        {
                            return Convert.ToInt32(read["id"]);
                        }
                    }
                    return -1;

                }
            }


        }


        //EDITAR USUARIO
        public bool EditarUsuario(UsuarioDTO usuarioDTO)
        {
            var resultado = false;

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Usuario_Editar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id", usuarioDTO.id));
                    comando.Parameters.Add(new SqlParameter("@rut", usuarioDTO.rut));
                    comando.Parameters.Add(new SqlParameter("@nombre", usuarioDTO.nombre));
                    comando.Parameters.Add(new SqlParameter("@apellido", usuarioDTO.apellido));
                    comando.Parameters.Add(new SqlParameter("@fecha_nac", usuarioDTO.fecha_nac));
                    comando.Parameters.Add(new SqlParameter("@correo", usuarioDTO.correo));
                    comando.Parameters.Add(new SqlParameter("@contraseña", usuarioDTO.contraseña));
                    comando.Parameters.Add(new SqlParameter("@telefono", usuarioDTO.telefono));
                    comando.Parameters.Add(new SqlParameter("@vigente", usuarioDTO.vigente));

                    comando.ExecuteNonQuery();

                    resultado = true;
                }
            }

            return resultado;
        }



        //ELIMINAR USUARIO
        public bool EliminarUsuario(int id)
        {
            var resultado = false;

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Usuario_Eliminar", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@id", id));

                    comando.ExecuteNonQuery();

                    resultado = true;
                }
            }

            return resultado;

        }

        public UsuarioDTO LogIn(string correo, string contraseña)
        {
            var Usuario = new UsuarioDTO();

            using (SqlConnection conn = ConexionDAL.SQLconnCanchas())
            {
                using (SqlCommand comando = new SqlCommand("Usuario_Login", conn))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@correo", correo));
                    comando.Parameters.Add(new SqlParameter("@contraseña", contraseña));

                    using (var read = comando.ExecuteReader())
                    {
                        read.Read();
                        if (read.HasRows)
                        {
                            Usuario.id = Convert.ToInt32(read["id"]);
                            Usuario.nombre = Convert.ToString(read["Nombre"]);
                        }
                    }
                }
            }

            return Usuario;
        }
    }
}
