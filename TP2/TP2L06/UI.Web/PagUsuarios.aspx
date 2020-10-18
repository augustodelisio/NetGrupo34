<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagUsuarios.aspx.cs" Inherits="UI.Web.PagUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            float: left;
            width: 309px;
        }
        .auto-style2 {
            float: left;
            width: 330px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="bloquePadre">
        <div class="bloqueHijo">
            <asp:Panel ID="gridPanel" runat="server" CssClass="tabla">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True"/>
                        <asp:BoundField HeaderText="Legajo" DataField="Legajo"/>
                        <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                        <asp:BoundField HeaderText="Clave" DataField="Clave" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                        <asp:BoundField HeaderText="Persona" DataField="IdPersona" />
                        <asp:BoundField HeaderText="Tipo Usuario" DataField="IdTipoUsuario" />
                    </Columns>
                    <SelectedRowStyle BackColor="#9BBCFF" ForeColor="Black" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="gridActionsPanel" runat="server" CssClass="botonera">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="boton">Editar</asp:LinkButton>
                <asp:LinkButton ID="elimiarLinkButton" runat="server" OnClick="elimiarLinkButton_Click" CssClass="boton">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="boton">Nuevo</asp:LinkButton>
            </asp:Panel>
        </div>
        <div class="auto-style2">
            <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="formulario pila">

                <asp:Label ID="legajoLabel" runat="server" Text="Legajo: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="legajoTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="legajoValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="usuarioLabel" runat="server" Text="Nombre de Usuario: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="usuarioTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="usuarioValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="claveLabel" runat="server" Text="Clave:" CssClass="formItem"></asp:Label>
                <asp:TextBox ID="claveTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="claveValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="repetirClaveLabel" Visible="false" runat="server" Text="Repetir Clave: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="repetirClaveTextBox" Visible="false" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="repiteClaveValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="idPersonaLabel" runat="server" Text="Persona: " CssClass="formItem"></asp:Label>
                <asp:DropDownList ID="idPersonaDDL" runat="server" CssClass="formItem ddl"></asp:DropDownList>

                <asp:Label ID="idTipoUsuarioLabel" runat="server" Text="Tipo de Usuario: " CssClass="formItem"></asp:Label>
                <asp:DropDownList ID="idTipoUsuarioDDL" runat="server" CssClass="formItem ddl"></asp:DropDownList>

            </asp:Panel>
            
            <asp:Panel ID="formActionPanel" runat="server" Visible="false" CssClass="botonera pila">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
