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
    public partial class Cards : System.Web.UI.Page
    {
        public List<Articulo> Lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(IsPostBack))
                {

                    Favoritos_Negocio negocio = new Favoritos_Negocio();
            Lista = negocio.listarFavoritos();
                    idRepeater.DataSource = Lista;
                    idRepeater.DataBind();

                }
            }
            catch (Exception ex )
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

            
        }

       

       
        


        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                Favoritos_Negocio negocio = new Favoritos_Negocio();
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                //int idUser = ((Users)Session["usuarioActivo"]).Id;
                negocio.elimiarFavorito(idArticulo);
                Response.Redirect("Favoritos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
    }

        
    }
