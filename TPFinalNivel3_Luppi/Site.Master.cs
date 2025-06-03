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
    public partial class Site : System.Web.UI.MasterPage
    {
        public string lupa = "data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 24 24' fill='white'><path d='M15.5 14h-.79l-.28-.27a6.5 6.5 0 0 0 1.48-5.34c-.47-2.78-2.79-5-5.59-5.34a6.505 6.505 0 0 0-7.27 7.27c.34 2.8 2.56 5.12 5.34 5.59a6.5 6.5 0 0 0 5.34-1.48l.27.28v.79l4.25 4.25c.41.41 1.08.41 1.49 0l.01-.01c.41-.41.41-1.08 0-1.49L15.5 14zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z'/></svg>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["LupaActiva"] = false;
                btnBuscar.ImageUrl = lupa;
            }
            if (Page is Default || Page is ABM)
            {
                btnBuscar.Visible = true;
                btnBuscar.Enabled = true;
            }
            if(!(Seguridad.UsuarioLogueado((Usuario)Session["usuario"])))
            {
                btnABM.Visible = false;
                btnPerfil.Visible = false;
                if (Page is ABM || Page is Perfil || Page is FormularioArticulos)
                {
                    Response.Redirect("Login.aspx",false);
                }
            }
            else
            {
                btnIniciarSesion.Visible = false;
                btnRegistrarse.Visible = false;
                btnCerrarSession.Visible = true;
                if(((Usuario)Session["usuario"]).ImagenUrl  != null)
                {
                    imgPerfil.ImageUrl = ((Usuario)Session["usuario"]).ImagenUrl;
                }

                if (!(Seguridad.EsAdmin((Usuario)Session["usuario"])))
                {
                    btnABM.Visible = false;
                    if (Page is ABM || Page is FormularioArticulos)
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx",false);
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            bool lupaActiva = (Session["LupaActiva"] as bool?) ?? false;
            lupaActiva = !lupaActiva;
            Session["LupaActiva"] = lupaActiva;
            

            string cerrarFiltros = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyNCAyNCI+PHBhdGggZD0iTTE5IDYuNDFMMTcuNTkgNSAxMiAxMC41OSA2LjQxIDUgNSA2LjQxIDEwLjU5IDEyIDUgMTcuNTkgNi40MSAxOSAxMiAxMy40MSAxNy41OSAxOSAxOSAxNy41OSAxMy40MSAxMnoiIGZpbGw9IndoaXRlIi8+PC9zdmc+";

            if (lupaActiva)
            {
                btnBuscar.ToolTip = "Desactivar filtros de busqueda";
                btnBuscar.AlternateText = "EsconderFiltro";
                btnBuscar.ImageUrl = cerrarFiltros;
                btnBuscar.CssClass = "nav-image-btn filtro-activo";
                
            }
            else
            {
                btnBuscar.CssClass = "nav-image-btn";
                btnBuscar.ToolTip = "Activar filtros de busqueda";
                btnBuscar.AlternateText = "Buscar";
                btnBuscar.ImageUrl = lupa;
                
            }

        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx",false);
        }

        protected void btnABM_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM.aspx",false);
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }
    }
}