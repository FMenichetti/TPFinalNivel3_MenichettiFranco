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
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            //creo lista de articulos
            Articulo_Negocio negocio = new Articulo_Negocio();
            Session.Add("Lista", negocio.listar());
            GridView1.DataSource = Session["Lista"];
            GridView1.DataBind();

            }
            catch (Exception ex )
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            int Id = int.Parse(GridView1.SelectedDataKey.Value.ToString());
            Response.Redirect("Formulario.aspx?id=" + Id, false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx", false);
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUsuarios.aspx", false);
        }
    }
}