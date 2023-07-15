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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIncorrecto.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            Acceso_Datos datos = new Acceso_Datos();
            Users_Negocio negocio = new Users_Negocio();
            Users user = new Users();
            try
            {
                user.Email = txtEmail.Text;
                user.Pass = txtContraseña.Text;
                if(user.Email != "" && user.Pass != "")
                {

                if (negocio.login(user))
                {
                    Session.Add("usuarioActivo", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Clear();
                    lblIncorrecto.Visible = true;
                }
                }
                else
                {
                    lblIncorrecto.Visible = true;
                }
            }

            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}