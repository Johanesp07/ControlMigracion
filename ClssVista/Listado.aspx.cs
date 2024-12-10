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
    public partial class Listado : System.Web.UI.Page
    {
        Entradas_SalidasLogica entradas_SalidaLogica = new Entradas_SalidasLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarEntradas();
                MostrarSalidas();
            }
        }
        private void MostrarEntradas()
        {
            List<Entradas> listaEntradas = entradas_SalidaLogica.ListarEntradas();
            gvEntradas.DataSource = listaEntradas;
            gvEntradas.DataBind();

            gvEntradas.UseAccessibleHeader = true;
            if (gvEntradas.HeaderRow != null)
            {
                gvEntradas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvEntradas.FooterRow != null)
            {
                gvEntradas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        private void MostrarSalidas()
        {
            List<Salidas> listaSalidas = entradas_SalidaLogica.ListarSalidas();
            gvSalidas.DataSource = listaSalidas;
            gvSalidas.DataBind();

            gvSalidas.UseAccessibleHeader = true;
            if (gvSalidas.HeaderRow != null)
            {
                gvSalidas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvSalidas.FooterRow != null)
            {
                gvSalidas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}