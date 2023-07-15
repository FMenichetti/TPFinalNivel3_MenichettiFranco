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
    
    public partial class EditarUsuario : System.Web.UI.Page
    {
        //public Boolean modificar = false;
        public bool confirmarEliminar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            if (Request.QueryString["Id"] != null)
            {
                //modificar = true;
                //btnAceptar.Visible = false;
            }
            if (Request.QueryString["Id"] != null && !IsPostBack)
            {


                Articulo_Negocio negocio = new Articulo_Negocio();
                int Id = int.Parse(Request.QueryString["Id"]);
                List<Users> lista = (List<Users>)Session["ListaUsers"];
                Users seleccionado = lista.Find(x => x.Id == Id);

                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                //txtEmail.Text = seleccionado.Email;
                txtPass.Text = seleccionado.Pass;
                txtId.Text = seleccionado.Id.ToString();
                txtImagen.Text = seleccionado.UrlImagenPerfil;
                txtImagen_TextChanged(sender, e);

            }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        //protected void btnAceptar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ListaUsuarios.aspx", false);
        //}

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
            Users_Negocio negocio = new Users_Negocio();
            Users seleccionado = new Users();

            seleccionado.Id = int.Parse(txtId.Text.ToString());
            seleccionado.Pass = txtPass.Text;
            seleccionado.Nombre = txtNombre.Text;
            seleccionado.Apellido = txtApellido.Text;
            seleccionado.UrlImagenPerfil = txtImagen.Text;

            negocio.modificarUser(seleccionado);
            Response.Redirect("ListaUsuarios.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminar = true;
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            ImgUrl.ImageUrl = txtImagen.Text;
        }

        protected void idConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {

                Users_Negocio negocio = new Users_Negocio();
                Users seleccionado = new Users();
                seleccionado.Id = int.Parse(txtId.Text.ToString());
                negocio.eliminarUser(seleccionado);
                Response.Redirect("ListaUsuarios.aspx", false);
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