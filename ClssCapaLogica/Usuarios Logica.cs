using ControlMigracion.ClssDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssCapaLogica
{
    public class Usuarios_Logica
    {
        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();
            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuarios
                            {
                                IDUsuario = Convert.ToInt32(dr["IDUsuario"]),
                                CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                Contrasena = dr["Contraseña"].ToString(),
                                Rol = dr["Rol"].ToString()
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los usuarios", ex);
                }
            }
        }
    }
}