<%@ Page Title="Formulario articulos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3_Luppi.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row mt-4">
            <div class="col-12">
                <form class="mb-4 row g-3">
                    <asp:UpdatePanel runat="server" ID="upFormulario">
                        <ContentTemplate>
                            <div class="col-md-6 form-column">
                                <div class="mb-3">
                                    <label for="lblNombre" class="form-label">Nombre</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                                    <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txtNombre" runat="server" ForeColor="Red" />
                                </div>
                                <div class="mb-3">
                                    <label for="lblCodigo" class="form-label">Codigo</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" />
                                    <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txtCodigo" runat="server" ForeColor="Red" />
                                </div>
                                <div class="mb-3">
                                    <label for="lblDescripcion" class="form-label">Descripcion</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion" />
                                    <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txtDescripcion" runat="server" ForeColor="Red" />
                                </div>
                                <div class="mb-3">
                                    <label for="lblPrecio" class="form-label">Precio</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio"  />
                                    <asp:Label ID="lblErrorFormato" runat="server" Text="" CssClass="form-label" ForeColor="Red" ></asp:Label>
                                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Campo requerido." ControlToValidate="txtPrecio" runat="server" ForeColor="Red" />
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="form-label" ErrorMessage="Formato inválido. Use números con hasta 4 decimales separados por una coma o punto."  ValidationExpression="^(?!-)\d+([,.]\d{1,4})?$" ControlToValidate="txtPrecio" runat="server" ForeColor="Red"/>
                                </div>
                                <div class="mb-3">
                                    <label for="lblMarca" class="form-label">Marca</label>
                                    <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="lblCategoria" class="form-label">Categoria</label>
                                    <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6 form-column">
                                <asp:UpdatePanel runat="server" ID="upImagenUrl" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="mb-3">
                                            <label for="lblImagenUrl" class="form-label">Imagen</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtImagenUrl" TextMode="MultiLine" />
                                            <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txtImagenUrl" runat="server" ForeColor="Red" />
                                            <div class="align-content-center">
                                                <asp:Button Text="↻ Cargar imagen" runat="server" ID="btnCargarImagen" OnClick="btnCargarImagen_Click" CssClass="btn btn-outline-primary" CausesValidation="false" />
                                            </div>
                                        </div>
                                        <div class="mb-3">
                                            <div class="ratio ratio-4x3 bg-light rounded">
                                                <asp:Image CssClass="img-fluid object-fit-contain" ID="imgImagenUrl" runat="server" ImageUrl="https://winguweb.org/wp-content/uploads/2022/09/placeholder.png" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                                <div class="mb-3">
                                    <div class="align-content-center">
                                        <asp:Button Text="Agregar articulo" runat="server" CssClass="btn btn-primary" ID="btnAgregarArticulo" OnClick="btnAgregarArticulo_Click" CausesValidation="true" />
                                        <asp:Button Text="Modificar" runat="server" CssClass="btn btn-primary" Visible="false" ID="btnModificarArticulo" OnClick="btnModificarArticulo_Click" CausesValidation="true" />
                                        <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" Visible="false" ID="btnEliminarArticulo" OnClick="btnEliminarArticulo_Click" CausesValidation="false" OnClientClick="return confirm('¿Estás seguro de eliminar este articulo?');" />
                                        <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                                    </div>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </form>
            </div>
        </div>
    </div>

</asp:Content>
