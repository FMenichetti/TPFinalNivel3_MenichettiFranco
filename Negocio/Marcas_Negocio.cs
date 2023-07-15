using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class Marcas_Negocio
    {
        public List<Marcas> listaMarcas()
        {
            List<Marcas> listaMarcas = new List<Marcas>();
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("select descripcion, Id from  Marcas ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Id = (int)datos.Lector["Id"];
                    listaMarcas.Add(aux);
                }

                return listaMarcas;
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
