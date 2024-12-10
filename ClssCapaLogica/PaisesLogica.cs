using ControlMigracion.ClssDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ControlMigracion.ClssCapaLogica
{
    public class PaisesLogica
    {
		public List<Paises> ListarPaises()
		{
			List<Paises> lista = new List<Paises>();
			using (SqlConnection conn = new SqlConnection(DBcon.conexion))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", conn);
				cmd.CommandType = CommandType.Text;
				try
				{
                    conn.Open();
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Paises
							{
								IDPais = Convert.ToInt32(dr["IDPais"]),
								NombrePais = dr["NombrePais"].ToString(),
								CodigoISO = dr["CodigoISO"].ToString()
							});
						}
					}
					return lista;
				}
				catch (Exception ex)
				{
					throw new Exception("Error al listar los países", ex);
				}
			}
		}
	}
}