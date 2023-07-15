using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class Users_Negocio
    {

        public List<Users> listarUsers()
        {
            List<Users> listaUser = new List<Users>();
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from users");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Users user = new Users();
                    user.Id = int.Parse(datos.Lector["Id"].ToString());
                    user.Email = datos.Lector["email"].ToString();
                    user.Pass = datos.Lector["pass"].ToString();
                    user.Nombre = datos.Lector["Nombre"].ToString();
                    user.Apellido = datos.Lector["Apellido"].ToString();
                    user.UrlImagenPerfil = datos.Lector["urlImagenPerfil"].ToString();
                    user.Admin = bool.Parse(datos.Lector["admin"].ToString());
                    listaUser.Add(user);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }




            return listaUser;
        }
        public void modificarUser(Users user)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("update	USERS set pass = @pass, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil where id=@Id");
                datos.setearParametro("@pass", user.Pass);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@urlImagenPerfil", user.UrlImagenPerfil);
                datos.setearParametro("@id", user.Id);
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

        public void eliminarUser(Users user)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("Delete USERS where Id= @Id ");
                datos.setearParametro("@Id", user.Id);
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
        public void nuevoUser(string email, string pass)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("INSERT into USERS ( email,pass) values (@email,@pass)");
                datos.setearParametro("@email", email);
                datos.setearParametro("@pass", pass);
                datos.ejecutarLectura();
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
        public bool login(Users usuario)
        {
            Acceso_Datos datos = new Acceso_Datos();
            try
            {
                datos.setearConsulta("select Id, nombre, apellido, urlImagenPerfil,admin from USERS where email= @email and pass= @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read() == true)
                {
                    usuario.Admin = (bool)datos.Lector["admin"];
                    usuario.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = datos.Lector["nombre"].ToString();
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = datos.Lector["apellido"].ToString();
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.UrlImagenPerfil = datos.Lector["urlImagenPerfil"].ToString();


                    return true;
                }
                else { return false; }
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
