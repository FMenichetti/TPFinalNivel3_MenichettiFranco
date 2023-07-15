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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> Lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblBusqueda.Visible = false;
                //Carga de cards
                Articulo_Negocio negocio = new Articulo_Negocio();
                Lista = negocio.listar();
                Session.Add("Lista", Lista);
                IdRepeater.DataSource = Lista;
                IdRepeater.DataBind();

                //Carga ddl categorias
                Categoria_Negocio categorias = new Categoria_Negocio();
                if (!(IsPostBack))
                {
                    ddlCategoria.DataSource = categorias.listaCategorias();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    string vacio = "";
                    ddlCategoria.Items.Add(vacio);
                    ddlCategoria.Items.FindByValue(vacio).Selected = true;
                }

                // Carga ddl marcas
                Marcas_Negocio marcas = new Marcas_Negocio();
                if (!(IsPostBack))
                {

                    ddlMarca.DataSource = marcas.listaMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    string vacio = "";
                    ddlMarca.Items.Add(vacio);
                    ddlMarca.Items.FindByValue(vacio).Selected = true;
                }

                //Boton administrador
                if (Seguridad.administradorSesionActiva(Session["usuarioActivo"]) == true)
                    btnAdinistrador.Visible = true;
                else
                    btnAdinistrador.Visible = false;

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }




        }

        protected void btnAdinistrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrador.aspx", false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Articulo_Negocio articulo = new Articulo_Negocio();

            string vacio = "";
            string categoria = "";
            string marca = "";

            try
            {
                //Valido Si selecciono vacio en categoria o marca para modificar consulta
                if (!(ddlCategoria.SelectedValue == vacio))
                {
                    categoria = " and C.Id = " + ddlCategoria.SelectedValue.ToString();
                };

                if (!(ddlMarca.SelectedValue == vacio))
                {
                    marca = " and m.Id = " + ddlMarca.SelectedValue.ToString();
                }

                string buscar = txtBuscar.Text;

                //Cargo lista filtrada por marca, categoria y texto
                Lista = ((List<Articulo>)articulo.filtrar(marca, categoria)).FindAll(x => x.Nombre.ToUpper().Contains(buscar.ToUpper()));
                Session.Add("Lista", Lista);
                IdRepeater.DataSource = Session["Lista"];
                IdRepeater.DataBind();

                //vista de lbl cuando no hay busqueda
                if (Lista.Count == 0)
                    lblBusqueda.Visible = true;
                else lblBusqueda.Visible = false;


                //reinicio a cero los filtros
                txtBuscar.Text = "";
                ddlCategoria.ClearSelection();
                ddlCategoria.Items.FindByValue(vacio).Selected = true;
                ddlMarca.ClearSelection();
                ddlMarca.Items.FindByValue(vacio).Selected = true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }



        }




    }
}


