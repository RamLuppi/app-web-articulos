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
    public partial class Default : System.Web.UI.Page
    {
        public bool articuloNulo;

        public bool filtroActivo => (bool?)Session["LupaActiva"] ?? false;


        protected void Page_Load(object sender, EventArgs e)
        {
            articuloNulo = false;

            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Session.Add("ListaArticulo", negocio.listar());
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
            if (!IsPostBack)
            {
                repRepetidor.DataSource = Session["ListaArticulo"];
                repRepetidor.DataBind();

                if (Session["LupaActiva"] == null)
                {
                    Session["LupaActiva"] = false;
                }
                ddlTipoDeFiltro2.Items.Add("Igual a");
                ddlTipoDeFiltro2.Items.Add("Menor a");
                ddlTipoDeFiltro2.Items.Add("Mayor a");
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = ((Button)sender).CommandArgument;
                Session.Add("IdSeleccionado", valor);

                Response.Redirect("DetalleProducto.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }




        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                lblError.Text = "";
                if (!Validacion.validaVacio(ddlTipoDeFiltro2))
                {
                    Session.Add("error", "Por favor seleccione un criterio de filtro.");
                    Response.Redirect("Error.aspx");
                }

                if (!Validacion.validaVacio(txtFiltro))
                {
                    lblError.Text = "Por favor ingrese un texto para filtrar.";
                    return;
                }

                string campo = ddlTipoDeFiltro.SelectedItem.ToString();
                string criterio = ddlTipoDeFiltro2.SelectedItem.ToString();
                string texto = txtFiltro.Text;

                if (campo == "Precio")
                {
                    texto = texto.Replace(",", ".");

                    Page.Validate();
                    if (!Page.IsValid)
                    {
                        lblError.Text = "Formato inválido. Use números con hasta 4 decimales separados por una coma o punto.";
                        return;
                    }
                }

                List<Articulo> listaFiltro = negocio.filtrar(campo, criterio, texto);

                Session["ListaFiltrada"] = listaFiltro;
                if (listaFiltro.Count() == 0)
                {
                    articuloNulo = true;

                }
                repRepetidor.DataSource = listaFiltro;
                repRepetidor.DataBind();

                upCards.Update();
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            
            try
            {
                ddlTipoDeFiltro2.Items.Clear();
                ddlTipoDeFiltro.ClearSelection();
                txtFiltro.Text = string.Empty;
                ddlTipoDeFiltro2.Items.Add("Igual a");
                ddlTipoDeFiltro2.Items.Add("Menor a");
                ddlTipoDeFiltro2.Items.Add("Mayor a");
                lblError.Text = "";
                repRepetidor.DataSource = Session["listaArticulo"];
                repRepetidor.DataBind();

                upCards.Update();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlTipoDeFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlTipoDeFiltro2.Items.Clear();

                if (ddlTipoDeFiltro.Text.ToString() == "Precio")
                {
                    ddlTipoDeFiltro2.Items.Add("Igual a");
                    ddlTipoDeFiltro2.Items.Add("Menor a");
                    ddlTipoDeFiltro2.Items.Add("Mayor a");
                }
                else
                {
                    ddlTipoDeFiltro2.Items.Add("Contiene");
                    ddlTipoDeFiltro2.Items.Add("Empieza con");
                    ddlTipoDeFiltro2.Items.Add("Termina con");
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
