<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3_Luppi.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center mt-4">
            <div class="col-md-5 col-lg-4">
                <form class="mb-4">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="mb-3">
                                <label for="lblEmail" class="form-label">Email</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TextMode="Email" />
                                <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txtEmail" runat="server" ForeColor="Red" />
                            </div>
                            <div class="mb-3">
                                <label for="lblContraseña" class="form-label">Contraseña</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtContraseña" type="password"  />
                                <asp:RequiredFieldValidator ErrorMessage="Campo requerido." ControlToValidate="txtContraseña" runat="server" ForeColor="Red" />
                            </div>
                            <asp:Button Text="Iniciar sesion" runat="server" CssClass="btn btn-primary" ID="btnIniciarSesion" OnClick="btnIniciarSesion_Click" CausesValidation="true"/>
                            <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-danger" ID="btnCancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
