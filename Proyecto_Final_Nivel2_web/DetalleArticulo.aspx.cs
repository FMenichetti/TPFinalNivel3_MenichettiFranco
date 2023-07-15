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
    public partial class DetalleArticulo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int IdArticulo = int.Parse(Request.QueryString["Id"]);//!=null) ? int.Parse(Request.QueryString["Id"].ToString()):0;
                List<Articulo> lista = (List<Articulo>)Session["Lista"];
                Articulo seleccionado = lista.Find(x => x.Id == IdArticulo);
                Articulo_Negocio negocio = new Articulo_Negocio();


                if (Request.QueryString["Id"] != null && !IsPostBack)
                {
                    //lista de Articulos
                    //int idArticulo = int.Parse(Request.QueryString["Id"]

                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtId.Text = seleccionado.Id.ToString();
                    txtCodigo.Text = seleccionado.Codigo;
                    imgUrl.ImageUrl = seleccionado.ImagenUrl;
                    txtMarca.Text = seleccionado.Marca.Descripcion.ToString();
                    txtCategoria.Text = seleccionado.Categoria.Descripcion.ToString();


                    if (((Users)Session["usuarioActivo"]) != null)
                    {
                        //Consulto para llenar el checkbox checked
                        int idUser = ((Users)Session["usuarioActivo"]).Id;
                        Favoritos_Negocio favoritosNegocio = new Favoritos_Negocio();
                        chkFavorito.Visible = true;
                        Articulo articuloFavorito = favoritosNegocio.consultaFavorito(idUser, seleccionado.Id);
                        if (articuloFavorito.Id == IdArticulo)
                            chkFavorito.Checked = true;
                        else
                            chkFavorito.Checked = false;
                    }
                    else
                        chkFavorito.Visible = false;

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void chkFavorito_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Favoritos_Negocio negocio = new Favoritos_Negocio();
                int idArticulo = int.Parse(Request.QueryString["Id"].ToString());
                int idUser = ((Users)Session["usuarioActivo"]).Id;

                if (chkFavorito.Checked)
                {
                    negocio.agregarFavorito(idArticulo, idUser);
                    Response.Redirect("DetalleArticulo.aspx?Id="+idArticulo, false);
                }
                else
                {
                    negocio.elimiarFavorito(idArticulo);
                    Response.Redirect("DetalleArticulo.aspx?Id="+idArticulo, false);
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