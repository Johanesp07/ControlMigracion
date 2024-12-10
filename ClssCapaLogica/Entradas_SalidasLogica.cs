using ControlMigracion.ClssDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssCapaLogica
{
    public class Entradas_SalidasLogica
    {
        public int RegistrarEntrada(Entradas entradas)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("RegistrarEntrada", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDViajero", entradas.IDViajero);
                    cmd.Parameters.AddWithValue("@FechaEntrada", entradas.FechaEntrada);
                    cmd.Parameters.AddWithValue("@IDPaisOrigen", entradas.IDPaisOrigen);
                    cmd.Parameters.AddWithValue("@IDUsuarioRegistro", entradas.IDUsuarioRegistro);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar la entrada", ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }

        public int RegistrarSalida(Salidas salidas)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("RegistrarSalida", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDViajero", salidas.IDViajero);
                    cmd.Parameters.AddWithValue("@FechaSalida", salidas.FechaSalida);
                    cmd.Parameters.AddWithValue("@IDPaisDestino", salidas.IDPaisDestino);
                    cmd.Parameters.AddWithValue("@IDUsuarioRegistro", salidas.IDUsuarioRegistro);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar la salida", ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }
        public List<Entradas> ListarEntradas()
        {
            List<Entradas> lista = new List<Entradas>();
            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Entradas", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Entradas
                            {
                                IDEntrada = Convert.ToInt32(dr["IDEntrada"]),
                                IDViajero = Convert.ToInt32(dr["IDViajero"]),
                                FechaEntrada = Convert.ToDateTime(dr["FechaEntrada"]),
                                IDPaisOrigen = Convert.ToInt32(dr["IDPaisOrigen"]),
                                IDUsuarioRegistro = Convert.ToInt32(dr["IDUsuarioRegistro"])
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las entradas", ex);
                }
            }
        }
        public List<Salidas> ListarSalidas()
        {
            List<Salidas> lista = new List<Salidas>();
            using (SqlConnection conn = new SqlConnection(DBcon.conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Salidas", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Salidas
                            {
                                IDSalida = Convert.ToInt32(dr["IDSalida"]),
                                IDViajero = Convert.ToInt32(dr["IDViajero"]),
                                FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                                IDPaisDestino = Convert.ToInt32(dr["IDPaisDestino"]),
                                IDUsuarioRegistro = Convert.ToInt32(dr["IDUsuarioRegistro"])
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las salidas", ex);
                }
            }
        }
    }
}