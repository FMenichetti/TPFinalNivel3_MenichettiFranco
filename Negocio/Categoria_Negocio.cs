using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Categoria_Negocio
    {
        public List<Categoria> listaCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("select descripcion, Id from CATEGORIAS  ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Id = (int)datos.Lector["Id"];
                    listaCategorias.Add(aux);
                }

                return listaCategorias;
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
