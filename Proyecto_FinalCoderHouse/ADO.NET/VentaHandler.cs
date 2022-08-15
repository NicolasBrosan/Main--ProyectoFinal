using Proyecto_FinalCoderHouse.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FinalCoderHouse.ADO.NET
{
    public class VentaHandler : DBHandler
    {
        public List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var queryVenta = "SELECT * FROM Venta";
                using (SqlCommand sqlCommand = new SqlCommand(queryVenta, sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();

                                ventas.Add(venta);
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return ventas;
        }
    }
}
