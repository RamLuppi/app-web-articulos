<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3_Luppi.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container min-vh-100 d-flex flex-column justify-content-center align-items-center text-center">
        <div class="text-danger mb-4">
            <i class="fas fa-exclamation-triangle fa-5x"></i>
        </div>

        <h1 class="display-4 mb-3">¡Ha ocurrido un error!</h1>
        <asp:Label ID="lblMensajeError" runat="server" CssClass="lead fs-4 mb-4"
            Text="Lo sentimos, ha ocurrido un problema al procesar tu solicitud." />

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlErrorDetalles" runat="server" CssClass="card mb-4 mx-auto" Style="max-width: 75%;" Visible="false">
                    <div class="card-header bg-danger text-white text-center">
                        Detalles técnicos
                    </div>
                    <div class="card-body text-center">
                        <asp:Label ID="lblError" Text="" runat="server" />
                    </div>
                </asp:Panel>
                <div class="d-flex flex-wrap justify-content-center gap-3 mt-4">
                    <button type="button" class="btn btn-primary px-4" onclick="window.history.back()">
                        <i class="fas fa-arrow-left me-2"></i>Volver atrás
                    </button>

                    <asp:Button ID="btnHome" runat="server" CssClass="btn btn-secondary px-4"
                        Text="Ir al inicio" OnClick="btnHome_Click" />

                    <asp:Button ID="btnMostrarDetalles" runat="server" CssClass="btn btn-outline-info px-4"
                        Text="Mostrar detalles" OnClick="btnMostrarDetalles_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
