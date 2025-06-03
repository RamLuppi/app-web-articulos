using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3_Luppi
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.UsuarioLogueado((Usuario)Session["usuario"]))
                {
                    try
                    {
                        Usuario usuario = (Usuario)(Session["usuario"]);
                        txtEmail.Text = usuario.Email;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        txtUrlImagenPerfil.Text = usuario.ImagenUrl;

                        if (!Validacion.validaVacio(((Usuario)Session["usuario"]).ImagenUrl))
                        {
                            imgImagenUrl.ImageUrl = ((Usuario)Session["usuario"]).ImagenUrl;
                        }
                        else
                        {
                            imgImagenUrl.ImageUrl = "https://winguweb.org/wp-content/uploads/2022/09/placeholder.png";
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Add("error", ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }
                    
                }
            }

        }

        protected void btnActualizarPerfil_Click(object sender, EventArgs e)
        {
            
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();

                Usuario usuario = (Usuario)(Session["usuario"]);
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.ImagenUrl = txtUrlImagenPerfil.Text;

                negocio.ActualizarUsuario(usuario);
                Session.Add("usuario", usuario);

                Response.Redirect("Perfil.aspx", false);
            }
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