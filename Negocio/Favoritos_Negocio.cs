using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Favoritos_Negocio
    {
        public List<Articulo> listarFavoritos()
        {
            List<Articulo> favoritos = new List<Articulo>();
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo,A.Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from FAVORITOS F, ARTICULOS A, USERS U , MARCAS M, CATEGORIAS C where a.Id=f.IdArticulo and u.Id=f.IdUser and m.Id=a.IdMarca and c.Id=a.IdCategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = int.Parse(datos.Lector["Id"].ToString());
                    articulo.Codigo = datos.Lector["Codigo"].ToString();
                    articulo.Nombre = datos.Lector["Nombre"].ToString();
                    articulo.Descripcion = datos.Lector["Descripcion"].ToString();
                    articulo.ImagenUrl = datos.Lector["ImagenUrl"].ToString();
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = datos.Lector["Categoria"].ToString();
                    articulo.Marca = new Marcas();
                    articulo.Marca.Descripcion = datos.Lector["Marca"].ToString();
                    articulo.Precio = decimal.Parse(datos.Lector["Precio"].ToString());
                    articulo.Favorito = true;
                    favoritos.Add(articulo);
                }
                return favoritos;
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
        public void elimiarFavorito(int intArticulo)
        {
            Acceso_Datos datos = new Acceso_Datos();

            try
            {
                datos.setearConsulta("Delete FAVORITOS where idArticulo= @IdArticulo");
                datos.setearParametro("@IdArticulo", intArticulo);
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
        public void agregarFavorito(int idArticulo, int idUser)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("INSERT into FAVORITOS( IdUser, IdArticulo) values (@IdUser, @IdArticulo)");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("@IdArticulo", idArticulo);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public Articulo consultaFavorito(int idUser, int idArticulo)
        {
            //List<Articulo> favoritos = new List<Articulo>();
            //Favoritos favorito = new Favoritos();
            Articulo articulo = new Articulo();
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo,A.Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio from FAVORITOS F, ARTICULOS A, USERS U , MARCAS M, CATEGORIAS C where A.Id=f.IdArticulo and U.ID=f.IdUser and m.Id=a.IdMarca and c.Id=a.IdCategoria and a.Id=@idArticulo");
                //datos.setearParametro("@idUser", idUser);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    articulo.Codigo = datos.Lector["Codigo"].ToString();
                    articulo.Id = int.Parse(datos.Lector["Id"].ToString());
                    articulo.Nombre = datos.Lector["Nombre"].ToString();
                    articulo.Descripcion = datos.Lector["Descripcion"].ToString();
                    articulo.ImagenUrl = datos.Lector["ImagenUrl"].ToString();
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = datos.Lector["Categoria"].ToString();
                    articulo.Marca = new Marcas();
                    articulo.Marca.Descripcion = datos.Lector["Marca"].ToString();
                    articulo.Precio = decimal.Parse(datos.Lector["Precio"].ToString());

                }
                return articulo;
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
    }

}
