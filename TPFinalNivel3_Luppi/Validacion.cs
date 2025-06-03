using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace negocio
{
    public class Validacion
    {
        public static bool validaVacio(object control)
        {
            if (control is TextBox controltxt)
            {
                if (string.IsNullOrWhiteSpace(controltxt.Text))
                {
                    return false;
                
                }
                else
                {
                    return true;
                }
            }
            
            if (control is DropDownList controlddl)
            {
               ;
                if(controlddl.SelectedItem != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
