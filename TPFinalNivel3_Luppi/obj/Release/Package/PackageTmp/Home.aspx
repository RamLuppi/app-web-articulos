<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPFinalNivel3_Luppi.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="upFiltroHome" UpdateMode="Conditional">
        <ContentTemplate>
            <%if (filtroActivo)
                { %>
            <div class="filter-container shadow-sm p-3 mb-2 bg-dark">
                <div class="row g-3 align-items-end">

                    <div class="col-md-3">
                        <div class="mb-3 position-relative">
                            <asp:Label ID="lblTipoDeFiltro" runat="server" Text="Tipo de filtro" CssClass="form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="ddlTipoDeFiltro" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoDeFiltro_SelectedIndexChanged">
                                <asp:ListItem Text="Precio" />
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Categoria" />
                                <asp:ListItem Text="Marca" />
                                <asp:ListItem Text="Descripcion" />
                                <asp:ListItem Text="Codigo" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="mb-3 position-relative">
                            <asp:Label ID="lblTioDeFiltro2" runat="server" Text="Criterio" CssClass="form-label fw-bold"></asp:Label>
                            <asp:DropDownList ID="ddlTipoDeFiltro2" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="mb-3 position-relative">
                            <asp:Label ID="lblFiltrar" runat="server" Text="Valor" CssClass="form-label fw-bold"></asp:Label>
                            <div class="input-group">
                                <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" placeholder="Escribe para filtrar..."></asp:TextBox>
                                <span class="input-group-text"><i class="fas fa-search"></i></span>
                            </div>
                            <asp:Label Text="" runat="server" CssClass="validator-error" ID="lblError" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="d-grid gap-2 d-md-flex justify-content-md-end mb-3">
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary me-md-2" OnClick="btnFiltrar_Click" />
                            <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary" OnClick="btnLimpiarFiltro_Click" CausesValidation="false" />
                        </div>
                    </div>
                    <asp:RegularExpressionValidator CssClass="validator-error" ID="validatorFiltro" ValidationExpression="^(?!-)\d+([,.]\d{1,4})?$" ControlToValidate="txtFiltro" runat="server" ForeColor="Red" Display="None" />
                </div>
            </div>
            <%} %>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>


    <asp:UpdatePanel runat="server" ID="upCards" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="album py-5 bg-body-tertiary">
                <div class="container">
                    <div class="row row-cols-1 row-cols-md-3 g-3">
                        <asp:Repeater runat="server" ID="repRepetidor">
                            <ItemTemplate>
                                <div class="col">
                                    <div class="card shadow-sm h-100">
                                        <div class="d-flex justify-content-between align-items-center card-body">
                                            <label id="lblNombre" class="card-text"><%#Eval("Nombre") %></label>
                                        </div>
                                        <img src='<%#Eval("ImagenUrl") %>' class="card-img-top" alt='<%#Eval("Nombre") %>' style="height: 225px; object-fit: cover;">
                                        <div class="card-body">
                                            <label id="lblDescripcion" class="card-text"><%#Eval("Descripcion") %></label>
                                            <label id="lblMarcaYCategoria" class="card-text">Su marca es <%#Eval("Marca") %> y su categoria es <%#Eval("Categoria") %>.</label>
                                            <div class="d-flex justify-content-between align-items-center card-body">
                                                <div class="btn-group">
                                                    <button disabled runat="server" id="btnPrecio" class="btn btn-success"><%#Eval("Precio") %></button>
                                                </div>
                                                <asp:Button CssClass="text-body-secondary" Text="Ver detalle" runat="server" ID="btnVerDetalle" OnClick="btnVerDetalle_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdSeleccionado" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <%if (articuloNulo)
                { %>
            <div class="album bg-body-tertiary">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-4">
                            <div class="card shadow-sm h-100">
                                <img src="https://i.pinimg.com/170x/6d/aa/75/6daa755a1c5f182d3ba316154e6ea371.jpg"
                                    class="card-img-top"
                                    alt="Artículo no encontrado"
                                    style="height: 225px; object-fit: cover;">

                                <div class="card-body">
                                    <h5 class="card-title">Upsss...</h5>
                                    <p class="card-text">No encontramos lo que buscas.</p>
                                </div>
                                <div class="card-body">
                                    <p class="card-text text-muted mb-3">Intenta con otros filtros o términos de búsqueda.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% } %>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnLimpiarFiltro" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlTipoDeFiltro" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>



</asp:Content>
