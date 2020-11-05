<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagCursos.aspx.cs" Inherits="UI.Web.PagCursos" %>
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
                    DataKeyNames="IdCurso" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="-->" ShowSelectButton="True"/>
                        <asp:BoundField HeaderText="Año" DataField="AnioCalendario"/>
                        <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                        <asp:BoundField HeaderText="Materia" DataField="IdMateria" />
                        <asp:BoundField HeaderText="Comision" DataField="IdComision" />
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
        <div class="bloqueHijo">
            <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="formulario">

                <asp:Label ID="anioLabel" runat="server" Text="Año: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="anioTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="anioValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="cupoLabel" runat="server" Text="Cupo: " CssClass="formItem"></asp:Label>
                <asp:TextBox ID="cupoTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="cupoValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion:" CssClass="formItem"></asp:Label>
                <asp:TextBox ID="descripcionTextBox" runat="server" CssClass="formItem bro"></asp:TextBox>
                <asp:Label ID="descripcionValidator" runat="server" CssClass="bro" ForeColor="Red"></asp:Label>

                <asp:Label ID="idMateriaLabel" runat="server" Text="Materia: " CssClass="formItem"></asp:Label>
                <asp:DropDownList ID="idMateriaDDL" runat="server" CssClass="formItem bro"></asp:DropDownList>

                <asp:Label ID="idComisionLabel" runat="server" Text="Comision: " CssClass="formItem"></asp:Label>
                <asp:DropDownList ID="idComisionDDL" runat="server" CssClass="formItem bro"></asp:DropDownList>

            </asp:Panel>
            
            <asp:Panel ID="formActionPanel" runat="server" Visible="false" CssClass="botonera">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="boton">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="boton">Cancelar</asp:LinkButton>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
