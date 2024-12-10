using ControlMigracion.ClssDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssCapaLogica
{
    public class LoginLogica
    {
        public Usuarios validarlogin( string correo, string contrasena) 
        {
            Usuarios usuarioEntidad = null;
            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correo));
                        cmd.Parameters.Add(new SqlParameter("@Contraseña", contrasena));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                usuarioEntidad = new Usuarios
                                {
                                    IDUsuario = rdr.GetInt32(rdr.GetOrdinal("IDUsuario")),
                                    CorreoElectronico = rdr.GetString(rdr.GetOrdinal("CorreoElectronico")),
                                    Rol = rdr.GetString(rdr.GetOrdinal("Rol"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al validar el login", ex);
                }
            }
            return usuarioEntidad;
        }
    } 
}