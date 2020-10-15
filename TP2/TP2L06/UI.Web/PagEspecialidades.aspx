<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagEspecialidades.aspx.cs" Inherits="UI.Web.PagEspecialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="bloquePadre">
        <div class="bloqueHijo">
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
                    SelectedRowStyle-BackColor="#88A6FF"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="IdEspecialidad" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="idEspecialidad" DataField="idEspecialidad" />
                        <asp:BoundField HeaderText="descripcion" DataField="descripcion" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="gridActionsPanel" runat="server">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="elimiarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
        </div>
        <div class="bloqueHijo">

            <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="formulario">

                <asp:Label ID="idEspecialidadLabel" runat="server" Text="ID Especialidad: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="idEspecialidadTextBox" runat="server"></asp:TextBox>

                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion Especialidad: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="formActionPanel" runat="server" Visible="false">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
