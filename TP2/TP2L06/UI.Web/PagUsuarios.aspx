<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagUsuarios.aspx.cs" Inherits="UI.Web.PagUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div>
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="Black"
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                    <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                    <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                    <asp:BoundField HeaderText="Clave" DataField="Clave" />
                    <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    <asp:BoundField HeaderText="Persona" DataField="IdPersona" />
                    <asp:BoundField HeaderText="Tipo Usuario" DataField="IdTipoUsuario" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">

            <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
            <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="usuarioLabel" runat="server" Text="Nombre de Usuario: "></asp:Label>
            <asp:TextBox ID="usuarioTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="repetirClaveLabel" Visible="false" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" Visible="false" TextMode="Password" runat="server"></asp:TextBox>

            <asp:Label ID="idPersonaLabel" runat="server" Text="Persona: "></asp:Label>
            <asp:TextBox ID="idPersonaTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="idTipoUsuarioLabel" runat="server" Text="Tipo de Usuario: "></asp:Label>
            <asp:TextBox ID="idTipoUsuarioTextbox" runat="server"></asp:TextBox>

            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
        </asp:Panel>

        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="elimiarLinkButton" runat="server" OnClick="elimiarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>

        <asp:Panel ID="formActionPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </div>
</asp:Content>
