using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class Seguridad
    {
        public static bool UsuarioLogueado(Usuario usuario)
        {
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool EsAdmin(Usuario usuario)
        {

            if (usuario.Admin == true && usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
