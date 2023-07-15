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
    public partial class Formulario : System.Web.UI.Page
    {

        public Boolean modificar = false;
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Id"] == null)
                {
                    
                CargarDdl();

                }
                //Modificar- Eliminar
                if (Request.QueryString["Id"] != null)
                {
                    modificar = true;
                    btnAceptar.Visible = false;

                }
                if (Request.QueryString["Id"] != null && !IsPostBack)
                {
                    CargarDdl();
                    Articulo_Negocio negocio = new Articulo_Negocio();
                    int Id = int.Parse(Request.QueryString["Id"]);
                    List<Articulo> lista = (List<Articulo>)Session["Lista"];
                    Articulo seleccionado = lista.Find(x => x.Id == Id);


                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtId.Text = seleccionado.Id.ToString();
                    txtCodigo.Text = seleccionado.Codigo;
                    txtImagen.Text = seleccionado.ImagenUrl;
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagen_TextChanged(sender, e);
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
            Response.Redirect("Administrador.aspx", false);
        }
        public void CargarDdl()
        {

            try
            {
                //Genero negocio y lista para DDL
                Categoria_Negocio negocioCategoria = new Categoria_Negocio();
                List<Categoria> listaCategorias = negocioCategoria.listaCategorias();
                Marcas_Negocio negocioMarcas = new Marcas_Negocio();
                List<Marcas> listaMarcas = negocioMarcas.listaMarcas();

                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            ImgUrl.ImageUrl = txtImagen.Text;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado = new Articulo();
                Articulo_Negocio negocio = new Articulo_Negocio();
                List<Articulo> modificada = (List<Articulo>)Session["Lista"];

                seleccionado.Nombre = txtNombre.Text;
                seleccionado.Precio = decimal.Parse(txtPrecio.Text);
                seleccionado.Descripcion = txtDescripcion.Text;
                seleccionado.Id = int.Parse(txtId.Text);
                seleccionado.Codigo = txtCodigo.Text;
                seleccionado.ImagenUrl = txtImagen.Text;
                seleccionado.Categoria = new Categoria();
                seleccionado.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                seleccionado.Marca = new Marcas();
                seleccionado.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                negocio.modificar(seleccionado);
                Response.Redirect("Administrador.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            confirmaEliminacion = true;
            

            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo_Negocio negocio = new Articulo_Negocio();
                Articulo nuevo = new Articulo();
                List<Articulo> lista = (List<Articulo>)Session["Lista"];

                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.ImagenUrl = txtImagen.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                lista.Add(nuevo);
                negocio.cargarNuevo(nuevo);
                Response.Redirect("Administrador.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
             
            try
            {
                if (chkConfirmacion.Checked)
                {

                Articulo seleccionado = new Articulo();
                Articulo_Negocio negocio = new Articulo_Negocio();
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("Administrador.aspx", false);

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