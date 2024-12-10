using ControlMigracion.ClssCapaLogica;
using ControlMigracion.ClssDatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlMigracion.ClssVista
{
    public partial class RegistrarViajeros : System.Web.UI.Page
    {
        private static int IDViajero = 0;
        PaisesLogica paisesLogica = new PaisesLogica();
        RegistrarViajerosLogica viajerosLogica = new RegistrarViajerosLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarPais();
                CargarViajeros();
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                 string.IsNullOrWhiteSpace(txtApellido.Text) ||
                 string.IsNullOrWhiteSpace(txtNroPasaporte.Text) ||
                 string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ||
                 string.IsNullOrWhiteSpace(ddlNacionalidad.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                Viajeros viajeros = new Viajeros()
                {
                    IDViajero = IDViajero,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    NroPasaporte = txtNroPasaporte.Text,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    Nacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue)
                };

                if (IDViajero == 0)
                {
                    int resultado = viajerosLogica.InsertarViajero(viajeros);
                   
                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/ClssVista/RegistrarViajeros.aspx");
                        string script = $"alert('Viajero ingresado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar viajero");
                    }
                }
            }
            catch (Exception ex)
            {
                Alertas("Ocurrió un error al procesar la solicitud: " + ex.Message);
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int IDViajero = Convert.ToInt32(ddlViajeros.SelectedValue);
            btnActualizar.Visible = true;
            btnAgregar.Visible = false;
            if (IDViajero != 0)
            {
                Viajeros viajero = viajerosLogica.ObtenerViajero(IDViajero);

                if (viajero != null)
                {
                    txtNombre.Text = viajero.Nombre;
                    txtApellido.Text = viajero.Apellido;
                    txtNroPasaporte.Text = viajero.NroPasaporte;
                    txtFechaNacimiento.Text = viajero.FechaNacimiento.ToString("yyyy-MM-dd");
                    ddlNacionalidad.SelectedValue = viajero.Nacionalidad.ToString();
                }
                else
                {
                    Alertas("No se encontró al viajero seleccionado.");
                }
            }
            else
            {
                Alertas("Por favor, seleccione un viajero válido.");
            }

        }
     

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int IDViajero = Convert.ToInt32(ddlViajeros.SelectedValue);
            int respuesta = viajerosLogica.EliminarViajero(IDViajero);

            if (respuesta > 0)
            {
                Alertas("El viajero ha sido eliminado con éxito");
                CargarViajeros();
            }
            else
            {
                Alertas("Error: Para eliminar a este viajero se debe de borrar su registro Entrada/Salida");
            }
        }
        protected void CargarPais()
        {
            List<Paises> listaPais = paisesLogica.ListarPaises();
            ddlNacionalidad.DataTextField = "NombrePais";
            ddlNacionalidad.DataValueField = "IDPais";
            ddlNacionalidad.DataSource = listaPais;
            ddlNacionalidad.DataBind();
        }
        protected void CargarViajeros()
        {
            List<Viajeros> Listviajeros = viajerosLogica.ListarViajeros();
            ddlViajeros.DataTextField = "Nombre";
            ddlViajeros.DataValueField = "IDViajero";
            ddlViajeros.DataSource = Listviajeros;
            ddlViajeros.DataBind();
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtApellido.Text) ||
        string.IsNullOrWhiteSpace(txtNroPasaporte.Text) ||
        string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ||
        string.IsNullOrWhiteSpace(ddlNacionalidad.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            btnActualizar.Visible = false;
            btnAgregar.Visible = true;
            try
            {
                Viajeros viajero = new Viajeros()
                {
                    IDViajero = Convert.ToInt32(ddlViajeros.SelectedValue),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    NroPasaporte = txtNroPasaporte.Text,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                    Nacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue)
                };
                if (viajero.IDViajero != 0)
                {
                    bool resultado = viajerosLogica.ActualizarViajero(viajero);

                    if (resultado)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/ClssVista/RegistrarViajeros.aspx");
                        string script = $"alert('Viajero actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar viajero");
                    }
                }
            }
            catch (Exception ex)
            {
                Alertas($"Error: {ex.Message}");
            }
        }
    }
}

