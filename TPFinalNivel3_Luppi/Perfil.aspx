<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3_Luppi.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-4">
            <div class="col-md-6">
                <form class="mb-4">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="mb-3">
                                <label for="lblEmail" class="form-label">Email</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" type="email" Enabled="false" />
                            </div>
                            <div class="mb-3">
                                <label for="lblNombre" class="form-label">Nombre</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                                <asp:RequiredFieldValidator ErrorMessage="Nombre requerido." ControlToValidate="txtNombre" runat="server" ForeColor="Red" />
                            </div>
                            <div class="mb-3">
                                <label for="lblApellido" class="form-label">Apellido</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                                <asp:RequiredFieldValidator ErrorMessage="Apellido requerido." ControlToValidate="txtApellido" runat="server" ForeColor="Red" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
            <div class="col-md-6">
                <asp:UpdatePanel runat="server" ID="upImagenUrl" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="lblUrlImagenPerfil" class="form-label">Url imagen perfil</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtUrlImagenPerfil" TextMode="MultiLine" Rows="3" />
                            <asp:RequiredFieldValidator ErrorMessage="Url de imagen requerida." ControlToValidate="txtUrlImagenPerfil" runat="server" ForeColor="Red" />
                        </div>
                        <div class="mb-4 text-center">
                            <div class="bg-light rounded border" style="width: 200px; height: 200px;">
                                <asp:Image CssClass="img-fluid h-100 w-100 object-fit-cover" ID="imgImagenUrl" runat="server"
                                    ImageUrl="https://winguweb.org/wp-content/uploads/2022/09/placeholder.png" />
                            </div>
                        </div>
                        <div class="d-flex gap-2 w-100 justify-content-center">
                            <asp:Button Text="Actualizar perfil" runat="server" CssClass="btn btn-primary flex-grow-1"
                                ID="btnActualizarPerfil" OnClick="btnActualizarPerfil_Click" CausesValidation="true" />
                            <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-outline-danger flex-grow-1"
                                ID="btnCancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
