using ControlMigracion.ClssDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssCapaLogica
{
    public class RegistrarViajerosLogica
    {
        public int InsertarViajero(Viajeros viajero)
        {
            using (var conn = new SqlConnection(DBcon.conexion))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@Nombre", viajero.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", viajero.Apellido);
                    cmd.Parameters.AddWithValue("@NroPasaporte", viajero.NroPasaporte);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", viajero.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Nacionalidad", viajero.Nacionalidad);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool ActualizarViajero(Viajeros viajero)
        {
            using (var conn = new SqlConnection(DBcon.conexion))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@IDViajero", viajero.IDViajero);
                    cmd.Parameters.AddWithValue("@Nombre", viajero.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", viajero.Apellido);
                    cmd.Parameters.AddWithValue("@NroPasaporte", viajero.NroPasaporte);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", viajero.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Nacionalidad", viajero.Nacionalidad);

                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public int EliminarViajero(int idViajero)
        {
            int result = 0;

            using (var conn = new SqlConnection(DBcon.conexion))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("GestionarViajeros", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@accion", "borrar");
                        cmd.Parameters.AddWithValue("@IDViajero", idViajero);


                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0) result = 1;
                    }
                    
                }
                catch (Exception ex)
                {
                throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }
    
        public List<Viajeros> ListarViajeros()
        {
            List<Viajeros> lista = new List<Viajeros>();
            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Viajeros", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Viajeros
                            {
                                IDViajero = Convert.ToInt32(dr["IDViajero"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                NroPasaporte = dr["NroPasaporte"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                Nacionalidad = Convert.ToInt32(dr["Nacionalidad"])
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los viajeros", ex);
                }
            }
        }

        public Viajeros ObtenerViajero(int idViajero)
        {
            using (var conn = new SqlConnection(DBcon.conexion))
            {
                conn.Open();
                using (var cmd = new SqlCommand("GestionarViajeros", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@IDViajero", idViajero);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Viajeros
                            {
                                IDViajero = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                NroPasaporte = reader.GetString(3),
                                FechaNacimiento = reader.GetDateTime(4),
                                Nacionalidad = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}