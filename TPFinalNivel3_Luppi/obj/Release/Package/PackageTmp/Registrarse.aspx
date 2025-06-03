<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPFinalNivel3_Luppi.Registrarse" %>

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
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" type="email"  />
                                <asp:RequiredFieldValidator ErrorMessage="El email es obligatorio." ControlToValidate="txtEmail" runat="server" ForeColor="Red" />
                            </div>
                            <div class="mb-3">
                                <label for="lblContraseña" class="form-label">Contraseña</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtContraseña" type="password"  />
                                <asp:RequiredFieldValidator ErrorMessage="La contraseña es obligatoria." ControlToValidate="txtContraseña" runat="server" ForeColor="Red" />
                            </div>
                            <asp:Button Text="Registrarse" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" CausesValidation="true" />
                            <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-danger" ID="btnCancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
