using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Users usuario = new Users();
            usuario = user != null ? (Users)user : null;
            if (usuario != null && usuario.Id!=0)
                return true;
            else
                return false;
        }
        public static bool administradorSesionActiva(object user)
        {
            Users usuario = new Users();
            usuario = user != null ? (Users)user : null;
            if (usuario != null && usuario.Id != 0 && usuario.Admin == true)
                return true;
            else
                return false;
        }
    }
}
