using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Luppi
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] == null)
            {
                Session["error"] = "Error inesperado. Intente nuevamente mas tarde.";
            }
            lblError.Text = (string)Session["error"];
        }

        protected void btnMostrarDetalles_Click(object sender, EventArgs e)
        {
            pnlErrorDetalles.Visible = !pnlErrorDetalles.Visible;
            if (pnlErrorDetalles.Visible)
            {
                btnMostrarDetalles.Text = "Ocultar detalles";
            }
            else
            {
                btnMostrarDetalles.Text = "Mostrar detalles";
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx",false);
        }

    }
}