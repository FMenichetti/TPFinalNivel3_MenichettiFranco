using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Proyecto_Final_Nivel2_web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Users_Negocio negocio = new Users_Negocio();
            try
            {
                Users user = new Users();
                user.Email = txtEmail.Text;
                user.Pass = txtContraseña.Text;
                if (user.Email != "" && user.Pass != "")
                {

                    negocio.nuevoUser(user.Email, user.Pass);
                    negocio.login(user);
                    Session.Add("usuarioActivo", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                    lblCompletarCampos.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}