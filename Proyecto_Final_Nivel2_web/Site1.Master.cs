using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Proyecto_Final_Nivel2_web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Default || Page is Error || Page is Login || Page is Registro || Page is DetalleArticulo))
            {
                if (!(Seguridad.sesionActiva(Session["usuarioActivo"])))
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }
            }

            //Visibilidad botones login y registrarse
            if (Seguridad.sesionActiva(Session["usuarioActivo"]))
            {
                btnRegistrarse.Visible = false;
                btnIngresar.Visible = false;
                btnSalir.Visible = true;
                lblSaludo.Visible = true;
                Users usuario = (Users)Session["usuarioActivo"];
                imgAvatar.ImageUrl = usuario.UrlImagenPerfil;
                name = usuario.Nombre;
               
            }
            else
            {
                btnRegistrarse.Visible = true;
                btnIngresar.Visible = true;
                btnSalir.Visible = false;
                lblSaludo.Visible = false;
                imgAvatar.Visible = false;
            }





        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",false);
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}