<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagEspecialidades.aspx.cs" Inherits="UI.Web.PagEspecialidades" %>

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
            <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-Height="40px"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="Black"
                    DataKeyNames="IdEspecialidad" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="idEspecialidad" DataField="idEspecialidad" />
                        <asp:BoundField HeaderText="descripcion" DataField="descripcion" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    </Columns>
                    <SelectedRowStyle BackColor="#9BBCFF" ForeColor="Black" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="gridActionsPanel" runat="server" CssClass="botonera">
                <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="elimiarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            </asp:Panel>
        </div>
        <div class="auto-style2">

            <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="formulario pila">
                
                <asp:Label ID="idEspecialidadLabel" runat="server" Text="Especialidad: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="idEspecialidadTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="idEspecialidadValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion Especialidad: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="descripcionTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="descripcionValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

            </asp:Panel>

            <asp:Panel ID="formActionPanel" runat="server" Visible="false"  CssClass="botonera pila">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
