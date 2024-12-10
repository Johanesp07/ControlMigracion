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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginLogica loginLogica = new LoginLogica();
            Usuarios usuarios = loginLogica.validarlogin(txtEmail.Text, txtPasword.Text);
            if (usuarios != null)
            {
                Response.Redirect("~/ClssVista/Inicio.aspx");
            }
            else
            {
                alertLabel.Text = "Credenciales incorrectas. Inténtalo de nuevo.";
                alertLabel.Visible = true;
            }
        }
    }
}