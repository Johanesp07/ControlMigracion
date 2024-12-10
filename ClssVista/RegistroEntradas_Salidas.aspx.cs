using ControlMigracion.ClssCapaLogica;
using ControlMigracion.ClssDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlMigracion.ClssVista
{
    public partial class RegistroEntradas_Salidas : System.Web.UI.Page
    {
        private static int IDEntradas_Salidas = 0;
        PaisesLogica paisesLogica = new PaisesLogica();
        RegistrarViajerosLogica viajerosLogica = new RegistrarViajerosLogica();
        Usuarios_Logica Usuarios_Logica = new Usuarios_Logica();
        Entradas_SalidasLogica entradas_SalidasLogica =  new Entradas_SalidasLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarPais();
                CargarViajeros();
                CargarUsuarios();
            }
        }
        protected void CargarViajeros()
        {
            List<Viajeros> Listviajeros = viajerosLogica.ListarViajeros();
            ddlViajeroEntrada.DataTextField = "Nombre";
            ddlViajeroEntrada.DataValueField = "IDViajero";
            ddlViajeroEntrada.DataSource = Listviajeros;
            ddlViajeroEntrada.DataBind();

        
            ddlViajeroSalida.DataTextField = "Nombre";
            ddlViajeroSalida.DataValueField = "IDViajero";
            ddlViajeroSalida.DataSource = Listviajeros;
            ddlViajeroSalida.DataBind();
        }
        protected void CargarPais()
        {
            List<Paises> listaPais = paisesLogica.ListarPaises();
            ddlPaisOrigen.DataTextField = "NombrePais";
            ddlPaisOrigen.DataValueField = "IDPais";
            ddlPaisOrigen.DataSource = listaPais;
            ddlPaisOrigen.DataBind();

           
            ddlPaisDestino.DataTextField = "NombrePais";
            ddlPaisDestino.DataValueField = "IDPais";
            ddlPaisDestino.DataSource = listaPais;
            ddlPaisDestino.DataBind();
        }
        protected void CargarUsuarios()
        {
            List<Usuarios> listUsuarios = Usuarios_Logica.ListarUsuarios();
            ddlUsuario.DataTextField = "CorreoElectronico";
            ddlUsuario.DataValueField = "IDUsuario";
            ddlUsuario.DataSource = listUsuarios;
            ddlUsuario.DataBind();

            
            ddlUsuario2.DataTextField = "CorreoElectronico";
            ddlUsuario2.DataValueField = "IDUsuario";
            ddlUsuario2.DataSource = listUsuarios;
            ddlUsuario2.DataBind();

        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFechaSalida.Text) ||
       
                string.IsNullOrWhiteSpace(ddlPaisDestino.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlViajeroSalida.SelectedValue) ||
                string.IsNullOrWhiteSpace(ddlUsuario.SelectedValue))
                
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                Salidas salidas = new Salidas()
                {
                    IDSalida = IDEntradas_Salidas,
                    IDViajero = Convert.ToInt32(ddlViajeroSalida.SelectedValue),
                    FechaSalida = Convert.ToDateTime(txtFechaSalida.Text),
                    IDPaisDestino = Convert.ToInt32(ddlPaisDestino.SelectedValue),
                    IDUsuarioRegistro = Convert.ToInt32(ddlUsuario.SelectedValue)
                };

                if (IDEntradas_Salidas == 0)
                {
                    int resultado = entradas_SalidasLogica.RegistrarSalida(salidas);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/ClssVista/RegistroEntradas_Salidas.aspx");
                        string script = $"alert('Salida realizada con exito'); window.location.href='{url}';";
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

        protected void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFechaEntrada.Text) ||

    string.IsNullOrWhiteSpace(ddlPaisOrigen.SelectedValue) ||
    string.IsNullOrWhiteSpace(ddlViajeroEntrada.SelectedValue) ||
    string.IsNullOrWhiteSpace(ddlUsuario2.SelectedValue))

            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                Entradas entradas = new Entradas()
                {
                    IDEntrada = IDEntradas_Salidas,
                    IDViajero = Convert.ToInt32(ddlViajeroEntrada.SelectedValue),
                    FechaEntrada = Convert.ToDateTime(txtFechaEntrada.Text),
                    IDPaisOrigen = Convert.ToInt32(ddlPaisOrigen.SelectedValue),
                    IDUsuarioRegistro = Convert.ToInt32(ddlUsuario2.SelectedValue)
                };

                if (IDEntradas_Salidas == 0)
                {
                    int resultado = entradas_SalidasLogica.RegistrarEntrada(entradas);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/ClssVista/RegistroEntradas_Salidas.aspx");
                        string script = $"alert('Entrada realizada con exito'); window.location.href='{url}';";
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
    }
}