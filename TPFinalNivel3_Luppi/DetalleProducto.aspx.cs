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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public string IdSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlMarca.ClearSelection();
            ddlCategoria.ClearSelection();
            
            try
            {
                if (!IsPostBack)
                {
                    if ((string)Session["IdSeleccionado"] != null)
                    {
                        IdSeleccionado = (string)Session["IdSeleccionado"];
                    }
                    else
                    {
                        Session.Add("error", "No seleccionaste ningun articulo en el Home. Vuelve a intentarlo.");
                        Response.Redirect("Error.aspx");
                    }
                }
                ArticulosNegocio negocio = new ArticulosNegocio();
                Articulo seleccionado = negocio.listar(IdSeleccionado)[0];

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Categoria> listaCategorias = categoriaNegocio.listar();
                List<Marca> listaMarcas = marcaNegocio.listar();


                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                txtNombre.Text = seleccionado.Nombre;
                txtCodigo.Text = seleccionado.Codigo;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtImagenUrl.Text = seleccionado.ImagenUrl;
                txtPrecio.Text = seleccionado.Precio.ToString();
                imgImagenUrl.ImageUrl = seleccionado.ImagenUrl;
                ddlCategoria.DataTextField = seleccionado.Categoria.Id.ToString();
                ddlMarca.DataTextField = seleccionado.Marca.Id.ToString();

                Session["IdSeleccionado"] = null;
            }
            catch (System.Threading.ThreadAbortException exs) { }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            

        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", false);
        }
    }
}