using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPFinalNivel3_Luppi
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();



                if (!Validacion.validaVacio(txtEmail) || !Validacion.validaVacio(txtContraseña))
                {
                    Session.Add("error", "Usuario o contraseña vacios.");
                    Response.Redirect("Error.aspx");
                }
                else
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Contraseña = txtContraseña.Text;
                }


                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseñas incorrectos. Vuelva a intentarlo.");
                    Response.Redirect("Error.aspx");
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}