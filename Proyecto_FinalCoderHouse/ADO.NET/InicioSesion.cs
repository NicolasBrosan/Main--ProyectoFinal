using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FinalCoderHouse.ADO.NET
{
    public class InicioSesion : DBHandler
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        public bool Sesion()
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var query = "SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña";

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = Contraseña });
                        sqlCommand.ExecuteNonQuery();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                respuesta = true;
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception)
            {
                return respuesta;
            }
            return respuesta;
        }

    }
}
