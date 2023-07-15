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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            Users_Negocio negocio = new Users_Negocio();
            Session.Add("ListaUsers", negocio.listarUsers());
            gvListaUsuarios.DataSource = Session["ListaUsers"];
            gvListaUsuarios.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void gvListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            int Id = int.Parse(gvListaUsuarios.SelectedDataKey.Value.ToString());
            Response.Redirect("EditarUsuario.aspx?id=" + Id, false);

            }
            catch (Exception ex )
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx", false);
        }
    }
}