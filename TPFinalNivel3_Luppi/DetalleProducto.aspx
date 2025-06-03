<%@ Page Title="Producto detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPFinalNivel3_Luppi.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row mt-4">
            <div class="col-12">
                <form class="mb-4 row g-3">
                    <div class="col-md-6 form-column">

                        <div class="mb-3">
                            <label for="lblNombre" class="form-label">Nombre</label>
                            <asp:textbox runat="server" cssclass="form-control" id="txtNombre" enabled="false" />
                        </div>
                        <div class="mb-3">
                            <label for="lblCodigo" class="form-label">Codigo</label>
                            <asp:textbox runat="server" cssclass="form-control" id="txtCodigo" enabled="false" />
                        </div>
                        <div class="mb-3">
                            <label for="lblDescripcion" class="form-label">Descripcion</label>
                            <asp:textbox runat="server" cssclass="form-control" id="txtDescripcion" enabled="false" />
                        </div>
                        <div class="mb-3">
                            <label for="lblPrecio" class="form-label">Precio</label>
                            <asp:textbox runat="server" cssclass="form-control" id="txtPrecio" enabled="false" />
                        </div>
                        <div class="mb-3">
                            <label for="lblMarca" class="form-label">Marca</label>
                            <asp:dropdownlist id="ddlMarca" cssclass="form-control" runat="server" enabled="false"></asp:dropdownlist>
                        </div>
                        <div class="mb-3">
                            <label for="lblCategoria" class="form-label">Categoria</label>
                            <asp:dropdownlist id="ddlCategoria" cssclass="form-control" runat="server" enabled="false"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="col-md-6 form-column">
                        <div class="mb-3">
                            <label for="lblImagenUrl" class="form-label">Imagen</label>
                            <asp:textbox runat="server" cssclass="form-control" id="txtImagenUrl" enabled="false" />
                        </div>
                        <div class="mb-3">
                            <div class="ratio ratio-4x3 bg-light rounded">
                                <asp:image cssclass="img-fluid object-fit-contain" id="imgImagenUrl" runat="server" imageurl="https://winguweb.org/wp-content/uploads/2022/09/placeholder.png" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <div class="align-content-center">
                                <asp:button text="Volver al menu principal" runat="server" cssclass="btn btn-danger" id="btnVolverMenu" onclick="btnVolverMenu_Click" />
                            </div>
                        </div>

                    </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
