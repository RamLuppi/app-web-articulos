<%@ Page Title="ABM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM.aspx.cs" Inherits="TPFinalNivel3_Luppi.ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="upFiltro">
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


            <div>
                <asp:GridView DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" runat="server" CssClass="table table-hover table-bordered align-middle" ID="dgvArticulos" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="<i class='fas fa-edit'></i>" ControlStyle-CssClass="btn btn-sm btn-outline-primary" />
                    </Columns>
                </asp:GridView>
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
                <div class="text-end mt-3">
                    <asp:Button Text="Agregar artículo" runat="server" ID="btnAgregarArticulo" OnClick="btnAgregarArticulo_Click" CssClass="btn btn-success mb-3" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
