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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
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
                if (negocio.usuarioRegistrado(usuario))
                {
                    Session.Add("error", "Ya hay un usuario registrado con el EMAIL:  " + usuario.Email + " .");
                    Response.Redirect("Error.aspx");
                }

                negocio.UsuarioNuevo(usuario);
                Session.Add("usuario", usuario);
                Response.Redirect("Perfil.aspx", false);
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }
    }
}