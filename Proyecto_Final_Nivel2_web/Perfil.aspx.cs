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
    public partial class Perfil : System.Web.UI.Page
    {
        Users user = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                user = (Users)Session["usuarioActivo"];
                if (!IsPostBack && user != null)
                {


                    txtApellido.Text = user.Apellido;
                    //txtContraseña.Text = user.Pass;
                    //txtContraseña2.Text = user.Pass;
                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    if (user.UrlImagenPerfil != null)
                    {
                        txtUrlImagen.Text = user.UrlImagenPerfil;
                        imgPerfil.ImageUrl = user.UrlImagenPerfil;
                    }
                    else txtUrlImagen.Text = "https://images.unsplash.com/photo-1562113530-57ba467cea38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=399&q=80";
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                Users_Negocio negocio = new Users_Negocio();
                //sers modificado = new Users();

                user.Nombre = txtNombre.Text;
                user.UrlImagenPerfil = txtUrlImagen.Text;
                user.Apellido = txtApellido.Text;


                negocio.modificarUser(user);
                Response.Redirect("Default.aspx", false);



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }


        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPerfil.ImageUrl = txtUrlImagen.Text;

        }
    }
}