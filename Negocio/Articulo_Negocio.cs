using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Articulo_Negocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo,Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, precio, IdCategoria, IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id and A.IdCategoria = C.Id ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void cargarNuevo(Articulo articulo)
        {
            try
            {
                Acceso_Datos datos = new Acceso_Datos();
                datos.setearConsulta(" Insert into ARTICULOS(Codigo,Nombre,Descripcion, ImagenUrl, precio, IdMarca, IdCategoria ) values (@Codigo, @Nombre, @Descripcion, @ImagenUrl, @precio, @IdMarca, @IdCategoria)");
                datos.setearParametro("@Codigo", articulo.Codigo.ToString());
                datos.setearParametro("@Nombre", articulo.Nombre.ToString());
                datos.setearParametro("@Descripcion", articulo.Descripcion.ToString());
                datos.setearParametro("@ImagenUrl", articulo.ImagenUrl.ToString());
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.ejecutarAccion();
                datos.cerrarConexion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificar(Articulo articulo)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Nombre = @Nombre, Codigo = @Codigo, Descripcion = @Descripcion, ImagenUrl = @ImagenUrl, Precio = @Precio, IdMarca = @IdMarca, IdCategoria = @IdCategoria where Id = @Id  ");
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@ImagenUrl", articulo.ImagenUrl);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }
        public void eliminar(int id)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @Id ");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Articulo> filtrar(string marca, string categoria)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            Acceso_Datos datos = new Acceso_Datos();

            try
            {

                datos.setearConsulta(" Select A.Id, Codigo,Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, precio from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id and A.IdCategoria = C.Id " + marca + categoria);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["precio"];

                    listaFiltrada.Add(aux);

                }

                datos.cerrarConexion();
                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void cargarNuevoConSp(Articulo articulo)
        //{
        //    Acceso_Datos datos = new Acceso_Datos();
        //    try
        //    {
        //    datos.setearProcedimiento("StoredNuevo");
        //    datos.setearParametro("@Codigo", articulo.Codigo.ToString());
        //    datos.setearParametro("@Nombre", articulo.Nombre.ToString());
        //    datos.setearParametro("@Descripcion", articulo.Descripcion.ToString());
        //    datos.setearParametro("@ImagenUrl", articulo.ImagenUrl.ToString());
        //    datos.setearParametro("@Precio", articulo.Precio);
        //    datos.setearParametro("@IdMarca", articulo.Marca.Id);
        //    datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
        //    datos.ejecutarAccion();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //    datos.cerrarConexion();

        //    }
        //}
        //public void modificarConSp(Articulo articulo)
        //{
        //    Acceso_Datos datos = new Acceso_Datos();
        //    try
        //    {
        //    datos.setearProcedimiento("StoredModificar");
        //    datos.setearParametro("@Nombre", articulo.Nombre);
        //    datos.setearParametro("@Codigo", articulo.Codigo);
        //    datos.setearParametro("@Descripcion", articulo.Descripcion);
        //    datos.setearParametro("@ImagenUrl", articulo.ImagenUrl);
        //    datos.setearParametro("@Precio", articulo.Precio);
        //    datos.setearParametro("@IdMarca", articulo.Marca.Id);
        //    datos.setearParametro("@IdCategoria", articulo.Marca.Id);
        //    datos.setearParametro("@Id", articulo.Id);
        //    datos.ejecutarAccion();

        //    }
        //    catch (Exception ex )
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //    datos.cerrarConexion();

        //    }
        //}
        //public void eliminarConSp(int id)
        //{
        //    Acceso_Datos datos = new Acceso_Datos();
        //    try
        //    {
        //    datos.setearProcedimiento("StoredEliminar");
        //    datos.setearParametro("@Id", id);
        //    datos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally { 
        //    datos.cerrarConexion();
            
        //    }
        //}
        //public List<Articulo> listarConSp()
        //{
        //    List<Articulo> lista = new List<Articulo>();
        //    Acceso_Datos datos = new Acceso_Datos();
        //    try
        //    {
        //        datos.setearProcedimiento("StoredListar");
        //        datos.ejecutarLectura();
        //        while (datos.Lector.Read())
        //        {
        //            Articulo aux = new Articulo();
        //            aux.Id = (int)datos.Lector["Id"];
        //            aux.Codigo = (string)datos.Lector["Codigo"];
        //            aux.Nombre = (string)datos.Lector["Nombre"];
        //            aux.Descripcion = (string)datos.Lector["Descripcion"];
        //            aux.Marca = new Marcas();
        //            aux.Marca.Id = (int)datos.Lector["IdMarca"];
        //            aux.Marca.Descripcion = (string)datos.Lector["Marca"];
        //            aux.Categoria = new Categoria();
        //            aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
        //            aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
        //            aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
        //            aux.Precio = (decimal)datos.Lector["Precio"];
        //            lista.Add(aux);
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();

        //    }
        //}


    }
}
