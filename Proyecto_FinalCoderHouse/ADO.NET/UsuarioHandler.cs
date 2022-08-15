using Proyecto_FinalCoderHouse.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FinalCoderHouse.ADO.NET
{
    public class UsuarioHandler : DBHandler
    {
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var queryUsuario = "SELECT * FROM Usuario";
                using (SqlCommand sqlCommand = new SqlCommand(queryUsuario, sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["Costo"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return usuarios;
        }
    }
}
