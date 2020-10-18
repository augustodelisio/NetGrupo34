<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagPersonas.aspx.cs" Inherits="UI.Web.PagPersonas" %>
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
                    DataKeyNames="IdPersona" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Direccion" DataField="Direccion" Visible="false"/>
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Email" DataField="Email" Visible="false" />
                        <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" DataFormatString="{0:MM/dd/yyyy}" />
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
            <asp:Panel  ID="formPanel" Visible="false" runat="server" CssClass="formulario pila">
                
                <asp:Label ID="nombrePersonaLabel" runat="server" Text="Nombre: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="nombreTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="nombreValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>
                
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="apellidoTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="apellidoValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>
                
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="direccionTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="direccionValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>
                               
                <asp:Label ID="emailLabel" runat="server" Text="Email: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="emailTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="emailValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="telefonoTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="telefonoValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="fechaNacimientoTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="fechaNacimientoValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

            </asp:Panel>

        <asp:Panel ID="formActionPanel" runat="server" Visible="false" CssClass="botonera pila">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
            </asp:Panel>
        
        </div>
    </div>
</asp:Content>
