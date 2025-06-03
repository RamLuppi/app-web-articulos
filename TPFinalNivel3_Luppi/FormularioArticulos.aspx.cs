using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Globalization;

namespace TPFinalNivel3_Luppi
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMarca.ClearSelection();
                ddlCategoria.ClearSelection();
                lblErrorFormato.Text = "";


                try
                {
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

                    string IdSeleccionado = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : IdSeleccionado = "";
                    if (IdSeleccionado != "" && !IsPostBack)
                    {
                        ArticulosNegocio negocio = new ArticulosNegocio();
                        Articulo seleccionado = negocio.listar(IdSeleccionado)[0];

                        txtNombre.Text = seleccionado.Nombre;
                        txtCodigo.Text = seleccionado.Codigo;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtImagenUrl.Text = seleccionado.ImagenUrl;
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        imgImagenUrl.ImageUrl = seleccionado.ImagenUrl;
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();

                        btnModificarArticulo.Visible = true;
                        btnEliminarArticulo.Visible = true;
                        btnAgregarArticulo.Visible = false;


                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }
            }

        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                ArticulosNegocio negocio = new ArticulosNegocio();
                Articulo nuevo = new Articulo();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                string texto = txtPrecio.Text.Replace(".", ",");
                nuevo.Precio = decimal.Parse(texto);


                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);


                negocio.agregar(nuevo);

                Response.Redirect("ABM.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM.aspx", false);
        }

        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                string IdSeleccionado = Request.QueryString["id"];

                negocio.eliminar(int.Parse(IdSeleccionado));
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            Response.Redirect("ABM.aspx", false);

        }

        protected void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                ArticulosNegocio negocio = new ArticulosNegocio();
                Articulo modificado = new Articulo();
                string IdSeleccionado = Request.QueryString["id"];


                modificado.Nombre = txtNombre.Text;
                modificado.Codigo = txtCodigo.Text;
                modificado.Descripcion = txtDescripcion.Text;
                modificado.ImagenUrl = txtImagenUrl.Text;

                string texto = txtPrecio.Text.Replace(".", ",");
                modificado.Precio = decimal.Parse(texto);

                modificado.Categoria = new Categoria();
                modificado.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                modificado.Marca = new Marca();
                modificado.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                modificado.Id = int.Parse(IdSeleccionado);

                negocio.modificar(modificado);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            Response.Redirect("ABM.aspx", false);
        }

        protected void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validacion.validaVacio(txtImagenUrl))
                {
                    imgImagenUrl.ImageUrl = txtImagenUrl.Text;
                }
                else
                {
                    imgImagenUrl.ImageUrl = "https://winguweb.org/wp-content/uploads/2022/09/placeholder.png";
                }
            }
            catch
            {
                imgImagenUrl.ImageUrl = "https://winguweb.org/wp-content/uploads/2022/09/placeholder.png";
            }
        }
    }
}